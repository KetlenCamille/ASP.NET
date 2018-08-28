using Ecommerce.DAO;
using Ecommerce.Models;
using Ecommerce.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        static ProdutoDAO produtoDAO = new ProdutoDAO();
        static CategoriaDAO categoriaDAO = new CategoriaDAO();
        static ItemVendaDAO itemVendaDAO = new ItemVendaDAO();
        static UsuarioDAO usuarioDAO = new UsuarioDAO();

        static VendaDAO vendaDAO = new VendaDAO();

        // GET: Home
        public ActionResult Index(int? id)
        {
            ViewBag.Categorias = categoriaDAO.ListarTodos();

            if (id == null)
            {
                return View(produtoDAO.ListarTodos());
            }

            return View(produtoDAO.ListarPorCategoria(id));
        }

        public ActionResult DetalhesProduto(int? id)
        {
            return View(produtoDAO.BuscarPorId(id));
        }

        public ActionResult AdicionarAoCarrinho(int id)
        {
            Produto produto = produtoDAO.BuscarPorId(id);
            foreach (ItemVenda item in itemVendaDAO.ListarPorCarrinho(Sessao.RetornarCarrinhoId().ToString()))
            {
                if (item.Produto.IdProduto == id)
                {
                    item.Quantidade += 1;

                    itemVendaDAO.Atualizar(item);
                    return RedirectToAction("CarrinhoCompras");
                }
            }
            ItemVenda itemVenda = new ItemVenda
            {
                Produto = produto,
                Quantidade = 1,
                Preco = produto.Preco,
                Data = DateTime.Now,
                CarrinhoId = Sessao.RetornarCarrinhoId().ToString()
            };
            itemVendaDAO.AdicionarItem(itemVenda);
            return RedirectToAction("CarrinhoCompras");
        }

        public ActionResult CarrinhoCompras()
        {
            double total = 0;
            foreach (ItemVenda item in itemVendaDAO.ListarPorCarrinho(Sessao.RetornarCarrinhoId().ToString()))
            {
                total += item.Preco * item.Quantidade;
            }

            ViewBag.Total = total;
            return View(itemVendaDAO.ListarPorCarrinho(Sessao.RetornarCarrinhoId().ToString()));
        }

        public ActionResult RemoverItemCarrinho(int? id)
        {
            ItemVenda item = itemVendaDAO.BuscarPorId(id);
            if (item != null)
            {
                if (item.Quantidade == 1)
                {
                    itemVendaDAO.Remover(id);
                }
                else
                {
                    item.Quantidade--;
                    itemVendaDAO.Atualizar(item);
                }
            }
            return RedirectToAction("CarrinhoCompras");
        }

        public ActionResult DiminuirQuantidade (int? id)
        {
            ItemVenda item = itemVendaDAO.BuscarPorId(id);
            if(item != null && item.Quantidade > 1)
            {
                item.Quantidade--;
                itemVendaDAO.Atualizar(item);
            }
            return RedirectToAction("CarrinhoCompras");
        }

        public ActionResult AumentarQuantidade(int? id)
        {
            ItemVenda item = itemVendaDAO.BuscarPorId(id);
            if (item != null)
            {
                item.Quantidade++;
                itemVendaDAO.Atualizar(item);
            }
            return RedirectToAction("CarrinhoCompras");
        }

        public ActionResult ResumoCompra()
        {
            double total = 0;
            foreach (ItemVenda item in itemVendaDAO.ListarPorCarrinho(Sessao.RetornarCarrinhoId().ToString()))
            {
                total += item.Preco * item.Quantidade;
            }

            ViewBag.Total = total;

            ViewBag.ItensVenda = itemVendaDAO.ListarPorCarrinho(Sessao.RetornarCarrinhoId().ToString());
            return View();
        }

        public ActionResult Comprar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Comprar(Usuario usuarioP)
        { 
            usuarioDAO.Cadastrar(usuarioP);

            Venda venda = new Venda
            {
                usuario = usuarioP,
                CarrinhoId = Sessao.RetornarCarrinhoId().ToString()
            };

            vendaDAO.Cadastrar(venda);
            Sessao.ZerarSessao();
            return RedirectToAction("Comprar");
        }
    }
}
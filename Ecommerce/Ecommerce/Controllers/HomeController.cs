using Ecommerce.DAO;
using Ecommerce.Models;
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

        // GET: Home
        public ActionResult Index(int? id)
        {
            ViewBag.Categorias = categoriaDAO.ListarTodos();

            if(id == null)
            {
                return View(produtoDAO.ListarTodos());
            }
            return View(produtoDAO.ListarPorCategoria(id));
        }

        public ActionResult DetalhesProduto (int? id)
        {
            return View(produtoDAO.BuscarPorId(id));
        }

        public ActionResult AdicionarAoCarrinho(int id)
        {
            Produto produto = produtoDAO.BuscarPorId(id);
            ItemVenda itemVenda = new ItemVenda
            {
                Produto = produto,
                Quantidade = 1,
                Preco = produto.Preco,
                Data = DateTime.Now
            };

            itemVendaDAO.AdicionarItem(itemVenda);
            return RedirectToAction("CarrinhoCompras");
        }

        public ActionResult CarrinhoCompras()
        {
            return View(itemVendaDAO.ListarTodos());
        }
        
    }
}
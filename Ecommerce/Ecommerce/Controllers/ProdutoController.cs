using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Models;
using Ecommerce.DAO;
using System.IO;

namespace Ecommerce.Controllers
{
    public class ProdutoController : Controller
    {
        static ProdutoDAO produtoDAO = new ProdutoDAO();
        static CategoriaDAO categoriaDAO = new CategoriaDAO();
        // GET: Produto
        public ActionResult Index()
        {
            ViewBag.Data = DateTime.Now;
            //ViewBag.Produtos = produtoDAO.ListarTodos();

            //Enviando a lista pelo retorno da View (quando não utiliza a ViewBag)
            return View(produtoDAO.ListarTodos());
        }

        public ActionResult CadastrarProduto()
        {
            ViewBag.Categorias = new SelectList(categoriaDAO.ListarTodos(), "idCategoria", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarProduto(Produto produto, int? Categorias, HttpPostedFileBase fupImagem)
        {
            ViewBag.Categorias = new SelectList(categoriaDAO.ListarTodos(), "idCategoria", "Nome");
            if(ModelState.IsValid)
            {
                if(Categorias != null)
                {
                    if (fupImagem != null)
                    {
                        string nomeImagem = produto.Nome + Path.GetExtension(Path.Combine(Server.MapPath("~/Imagens/"), Path.GetFileName(fupImagem.FileName)));
                        string caminho = Path.Combine(Server.MapPath("~/Imagens/"), nomeImagem);

                        fupImagem.SaveAs(caminho);

                        produto.Imagem = nomeImagem; 
                    }
                    else
                    {
                        produto.Imagem = "semImagem.png";
                    }

                    produto.Categoria = categoriaDAO.BuscarPorId(Categorias);
                    if (produtoDAO.Cadastrar(produto))
                    {
                        return RedirectToAction("Index", "Produto");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Não é possível adicionar um produto com o mesmo nome!");
                        return View(produto);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Selecione uma categoria!");
                    return View(produto);
                }
            }
            else
            {
                return View(produto);
            }       
        }

        public ActionResult EditarProduto(int id)
        {
            return View(produtoDAO.BuscarPorId(id));
        }

        public ActionResult ExcluirProduto(int id)
        {
            produtoDAO.Excluir(id);
            return RedirectToAction("Index", "Produto");
        }

        [HttpPost]
        public ActionResult EditarProduto(Produto produtoAlterado)
        {
            Produto produtoOriginal = produtoDAO.BuscarPorId(produtoAlterado.IdProduto);

            produtoOriginal.Nome = produtoAlterado.Nome;
            produtoOriginal.Descricao = produtoAlterado.Descricao;
            produtoOriginal.Preco = produtoAlterado.Preco;
            produtoOriginal.Categoria = produtoAlterado.Categoria;

            produtoDAO.Editar(produtoOriginal);
            return RedirectToAction("Index", "Produto");
        }

       
    }
}
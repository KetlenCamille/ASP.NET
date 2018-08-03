using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Models;
using Ecommerce.DAO;

namespace Ecommerce.Controllers
{
    public class ProdutoController : Controller
    {
        ProdutoDAO produtoDAO = new ProdutoDAO();
        private Context context = new Context();
        // GET: Produto
        public ActionResult Index()
        {
            ViewBag.Data = DateTime.Now;
            ViewBag.Produtos = context.Produtos.ToList();
            return View();
        }

        public ActionResult CadastrarProduto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarProduto(string nomeProduto, string descricaoProduto, string precoProduto, string categoriaProdudo)
        {
            Produto produto = new Produto
            {
                Nome = nomeProduto,
                Descricao = descricaoProduto,
                Preco = Convert.ToDouble(precoProduto),
                Categoria = categoriaProdudo
            };

            produtoDAO.Cadastrar(produto);
            return RedirectToAction("Index", "Produto");
        }

        public ActionResult EditarProduto(int id)
        {
            ViewBag.Produto = context.Produtos.Find(id);
            return View();
        }

        public ActionResult ExcluirProduto(int id)
        {
            produtoDAO.Excluir(id);
            return RedirectToAction("Index", "Produto");
        }

        [HttpPost]
        public ActionResult EditarProduto(string nomeProduto, string descricaoProduto, string precoProduto, string categoriaProdudo, int idProduto)
        {
            Produto produto = produtoDAO.BuscarPorId(idProduto);

            produto.Nome = nomeProduto;
            produto.Descricao = descricaoProduto;
            produto.Preco = Convert.ToDouble(precoProduto);
            produto.Categoria = categoriaProdudo;

            produtoDAO.Editar(produto);
            return RedirectToAction("Index", "Produto");
        }
    }
}
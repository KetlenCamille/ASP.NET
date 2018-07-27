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

            if(produto != null)
            {
                context.Produtos.Add(produto);
                context.SaveChanges();
            }
            return RedirectToAction("Index", "Produto");
        }
    }
}
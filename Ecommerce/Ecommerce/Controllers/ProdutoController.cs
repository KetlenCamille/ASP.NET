using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce.Models;

namespace Ecommerce.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
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
            return View();
        }
    }
}
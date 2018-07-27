using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult CadastrarProduto(string nomeProduto, string descricaoProduto, string precoProduto, string categoriaProdudo)
        {
            return View();
        }
    }
}
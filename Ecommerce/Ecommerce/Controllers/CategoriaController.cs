using Ecommerce.DAO;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class CategoriaController : Controller
    {
        static CategoriaDAO categoriaDAO = new CategoriaDAO();
        // GET: Categoria
        public ActionResult Index()
        {
            return View(categoriaDAO.ListarTodos());
        }

        public ActionResult CadastrarCategoria()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarCategoria(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                categoriaDAO.Cadastrar(categoria);
                return RedirectToAction("Index", "Categoria");
            }
            else
            {
                ModelState.AddModelError("", "Não é possível adicionar uma categoria com o mesmo nome!");
                return View(categoria);
            }
        }

        public ActionResult EditarCategoria(int id)
        {
            return View(categoriaDAO.BuscarPorId(id));
        }

        public ActionResult ExcluirCategoria(int id)
        {
            return RedirectToAction("Index", "Categoria");
        }

        [HttpPost]
        public ActionResult EditarCategoria(Categoria categoriaAlterada)
        {
            Categoria categoriaOriginal = categoriaDAO.BuscarPorId(categoriaAlterada.idCategoria);

            categoriaOriginal.Nome = categoriaAlterada.Nome;
            categoriaOriginal.Descricao = categoriaAlterada.Descricao;

            categoriaDAO.Editar(categoriaOriginal);
            return RedirectToAction("Index", "Categoria");
        }
    }
}
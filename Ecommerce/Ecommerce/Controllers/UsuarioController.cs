using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce.DAO;
using Ecommerce.Models;
using System.Web.Security;

namespace Ecommerce.Controllers
{
    public class UsuarioController : Controller
    {
        static UsuarioDAO usuarioDAO = new UsuarioDAO();
        // GET: Usuario
        public ActionResult Index()
        {
            return View(usuarioDAO.ListarTodos());
        }

        public ActionResult CadastrarUsuario ()
        {
            ViewBag.Usuarios = new SelectList(usuarioDAO.ListarTodos(), "idUsuario", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarUsuario(Usuario usuario)
        {
            if(ModelState.IsValid)
            {
                if(usuarioDAO.Cadastrar(usuario))
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("","Esse usuário já existe!");
                return View(usuario);
            }
            return View(usuario);
        }

        public ActionResult EditarUsuario(int id)
        {
            return View(usuarioDAO.BuscarPorId(id));
        }

        public ActionResult ExcluirUsuario(int id)
        {
            return RedirectToAction("Index", "Usuario");
        }

        [HttpPost]
        public ActionResult EditarUsuario(Usuario usuarioAlterado)
        {
            Usuario usuarioOriginal = usuarioDAO.BuscarPorId(usuarioAlterado.UsuarioId);

            usuarioOriginal.Nome = usuarioAlterado.Nome;
            usuarioOriginal.Email = usuarioAlterado.Email;
            usuarioOriginal.Senha = usuarioAlterado.Senha;

            usuarioDAO.Atualizar(usuarioOriginal);
            return RedirectToAction("Index", "Usuario");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            Usuario user = usuarioDAO.Autenticar(usuario);
            if(user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Email, false);
                return RedirectToAction("Index", "Produto");
            }
            ModelState.AddModelError("", "Usuário não encontrado!");
            return View(usuario);
        }

        public ActionResult Logout ()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
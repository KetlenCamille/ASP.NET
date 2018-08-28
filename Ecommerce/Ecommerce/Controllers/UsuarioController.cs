﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce.DAO;
using Ecommerce.Models;

namespace Ecommerce.Controllers
{
    public class UsuarioController : Controller
    {
        static UsuarioDAO usuarioDAO = new UsuarioDAO();
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CadastrarUsuario ()
        {
            ViewBag.Usuarios = new SelectList(usuarioDAO.ListarTodos(), "idUsuario", "Nome");
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarUsuario(Usuario usuario)
        {
            ViewBag.Usuarios = new SelectList(usuarioDAO.ListarTodos(), "idUsuario", "Nome");
            if(usuario != null)
            {
                usuarioDAO.Cadastrar(usuario);
                return RedirectToAction("Login");
            }
            else
            {
                return View(usuario);
            }

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
            if(usuarioDAO.Autenticar())
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("LoginNaoEncontrado");
        }
    }
}
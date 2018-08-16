﻿using Ecommerce.DAO;
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

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Categorias = categoriaDAO.ListarTodos();
            return View(produtoDAO.ListarTodos());
        }

        public ActionResult FiltrarCategorias (int? id)
        {
            ViewBag.Categorias = produtoDAO.ListarTodos();
            return View(produtoDAO.ListarPorCategoria(id));
        }

        public ActionResult DetalhesProduto (int? id)
        {
            return View(produtoDAO.BuscarPorId(id));
        }
    }
}
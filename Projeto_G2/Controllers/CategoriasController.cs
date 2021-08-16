using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Projeto_G2.Context;
using System.Net;
using System.Data.Entity;
using Modelo.Tabelas;
using Modelo.Cadastros;
using Serviço.Cadastros;
using Serviço.Tabelas;

namespace Projeto_G2.Controllers
{
    public class CategoriasController : Controller
    {
        private CategoriaServico CategoriaServico = new CategoriaServico();
        private ActionResult ObterVisaoCategoriaPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Categoria categoria = CategoriaServico.ObterCategoriaPorId((long)id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        private ActionResult GravarCategoria(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CategoriaServico.GravarCategoria(categoria);
                    return RedirectToAction("Index");
                }
                return View(categoria);
            }
            catch
            {
                return View(categoria);
            }
        }



        // GET: Categoria
        public ActionResult Index()
        {
            return View(CategoriaServico.ObterCategoriasClassificadasPorNome());
        }


        // GET: Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Categoria(Categoria categoria)
        {
            return GravarCategoria(categoria);
        }


        // GET: Edit
        public ActionResult Edit(long? id)
        {
            return ObterVisaoCategoriaPorId(id);
        }


        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            return GravarCategoria(categoria);
        }


        // GET: Details
        public ActionResult Details(long? id)
        {
            return ObterVisaoCategoriaPorId(id);
        }


        // GET: Delete
        public ActionResult Delete(long? id)
        {
            return ObterVisaoCategoriaPorId(id);
        }


        // POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Categoria categoria = CategoriaServico.EliminarCategoriaPorId(id);
                TempData["Message"] = "Categoria " + categoria.Nome.ToUpper() + " foi removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
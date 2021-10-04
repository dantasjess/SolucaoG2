using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Modelo.Cadastros;
using Serviço.Cadastros;

namespace Projeto_G2.Areas.Cadastros.Controllers
{
        public class FabricantesController : Controller
        {
            //private EFContext context = new EFContext();

            private FabricanteServico fabricanteServico = new FabricanteServico();
        private ActionResult ObterVisaoFabricantePorId(long? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
                }
                Fabricante fabricante = fabricanteServico.ObterFabricantePorId((long)id);
                if (fabricante == null)
                {
                    return HttpNotFound();
                }
                return View(fabricante);
            }


            private ActionResult GravarFabricante(Fabricante fabricante)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        fabricanteServico.GravarFabricante(fabricante);
                        return RedirectToAction("Index");
                    }
                    return View(fabricante);
                }
                catch
                {
                    return View(fabricante);
                }
            }



            // GET: Fabricantes
            public ActionResult Index()
            {
                return View(fabricanteServico.ObterFabricantesClassificadosPorNome());
            }


            // GET: Create
            public ActionResult Create()
            {
                return View();
            }


            // POST: Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(Fabricante fabricante)
            {
                return GravarFabricante(fabricante);
            }


            // GET: Edit
            public ActionResult Edit(long? id)
            {
                return ObterVisaoFabricantePorId(id);
            }


            // POST: Edit
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(Fabricante fabricante)
            {
                return GravarFabricante(fabricante);
            }


            // GET: Details
            public ActionResult Details(long? id)
            {
                return ObterVisaoFabricantePorId(id);
            }


            // GET
            public ActionResult Delete(long? id)
            {
                return ObterVisaoFabricantePorId((long)id);
            }

            // POST
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Delete(long id)
            {
                try
                {
                    Fabricante fabricante = fabricanteServico.EliminarFabricantePorId(id);
                    TempData["Message"] = "Fabricante " + fabricante.Nome.ToUpper() + " foi removido";
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
    }
}

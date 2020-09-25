using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_Proyectos.Controllers
{[Authorize(Roles ="Admin")]
    public class DepartamentoController : Controller
    {
        // GET: Departamento
        public ActionResult Index()
        {
            List<Departamento> list = DepartamentoCN.ListaDepartamentos();
            return View(list);
        }
        public JsonResult getDepartamento() {
            var list = DepartamentoCN.ListaDepartamentos();
            return Json(new { data = list }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Crear()
        {
            return View();
        }

        public ActionResult Detalles(int id)
        {
            Departamento dpto = DepartamentoCN.Detalles(id);
            return View(dpto);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Departamento dpto)
        {
            if (!ModelState.IsValid)
            {
                return View(dpto);
            }
            try
            {
                DepartamentoCN.Crear(dpto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("",ex.Message) ;
                throw;
            }
            return RedirectToAction("Index");
        }
        public ActionResult Editar(int id)
        {
            Departamento dpto = DepartamentoCN.Detalles(id);
            return View(dpto);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Departamento dpto)
        {
            try
            {
                DepartamentoCN.Edit(dpto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                throw;
            }
        }
        public ActionResult Eliminar(int id)
        {
            DepartamentoCN.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}
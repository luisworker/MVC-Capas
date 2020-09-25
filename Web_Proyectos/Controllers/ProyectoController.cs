using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Web_Proyectos.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ProyectoController : Controller
    {
        // GET: Proyecto
        public ActionResult Index()
        {
            var a = ProyectoCN.ListaProyectos();
            return View(a);
        }
        public ActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Proyecto proy)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                if (proy.NombreProyecto == null || proy.NombreProyecto == "")
                {
                    return Json(new { ok = false , msg = "Especifique el nombre" }, JsonRequestBehavior.AllowGet);
                }
                
                ProyectoCN.Crear(proy);

                return Json(new { ok = true, toRedirect = Url.Action("Index","Proyecto") }, JsonRequestBehavior.AllowGet);
                
                // return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet );
            }
            
        }
        public ActionResult Editar(int id)
        {
           var proy= ProyectoCN.Detalles(id);
            return View(proy);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Proyecto proy)
        {
            try
            {
                if (proy.NombreProyecto==""||proy.NombreProyecto==null)
                {
                    return Json(new { ok = false, msg="Debe especificar nombre del proyecto" }, JsonRequestBehavior.AllowGet);
                }
                System.Threading.Thread.Sleep(1000);
                ProyectoCN.Editar(proy);
                return Json(new { ok = true, toRedirect = Url.Action("Index","Proyecto")},JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
                
            }
            
        }
        public ActionResult Detalles(int id)
        {
            return View(ProyectoCN.Detalles(id));
        }
       
        [HttpPost]
        public ActionResult Eliminar(int id) 
         {
            try
            {
                
                ProyectoCN.Eliminar(id);
                return Json(new { ok = true, data = Url.Action("Index", "Proyecto") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = "Problema en el proceso " + ex.Message }, JsonRequestBehavior.AllowGet) ;
                
            }
            

        }
        public ActionResult AsignarProyectos()
        {
            var a=ProyectoEmpleadoCN.GetAsignados();
            return View(a);
        }
        [HttpPost]
        public ActionResult AsignarProyectos(int EmpleadoId,int ProyectoId)
        {
            try
            {
                if (ProyectoEmpleadoCN.ExisteAsignacion(EmpleadoId,ProyectoId))
                {
                    return Json(new { ok = false, Message = "Este empleado ya ha sido asignado a este Proyecto" }, JsonRequestBehavior.AllowGet);
                }
                if (ProyectoCN.Detalles(ProyectoId).FechaFin>DateTime.Now)
                {
                    ProyectoEmpleadoCN.AsignarProyecto(EmpleadoId, ProyectoId);
                    return Json(new { ok = true, toRedirect = Url.Action("AsignarProyectos", "Proyecto") }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { ok = false, Message = "Proyecto ya terminado" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, Message=ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult EliminarAsignacion(int EmpleadoId, int ProyectoId)
        {
            try
            {
                ProyectoEmpleadoCN.EliminarAsignacion(EmpleadoId, ProyectoId);
                return Json(new { ok = true, toRedirect = Url.Action("AsignarProyectos", "Proyecto") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult ObtenerProyectos()
        {
            try
            {
                var d = ProyectoCN.ListaProyectosJson();
                return Json(new { data = d }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message }, JsonRequestBehavior.AllowGet);
                
            }
        }
    }
    
    
}
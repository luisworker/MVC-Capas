using Negocio;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportAppServer;
using CrystalDecisions.Shared;
using System.Net;
using System.IO;

namespace Web_Proyectos.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            var a = EmpleadoCN.ListaEmpleados();
            return View(a);
        }
        public ActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear(Empleado emple)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                if (emple.Nombres == "" || emple.Apellidos == "")
                {
                    return Json(new { ok = false, msg = "Especifique el nombre" }, JsonRequestBehavior.AllowGet);
                }

                EmpleadoCN.Crear(emple);

                return Json(new { ok = true, toRedirect = Url.Action("Index", "Empleado") }, JsonRequestBehavior.AllowGet);

                // return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult Editar(int id)
        {
            var emple = EmpleadoCN.Detalles(id);
            return View(emple);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(VMEmpleado emple)
        {
            try
            {
                if (emple.Nombres == "" || emple.Apellidos =="")
                {
                    return Json(new { ok = false, msg = "Debe especificar nombre y los apellidos del Empleado" }, JsonRequestBehavior.AllowGet);
                }
                System.Threading.Thread.Sleep(1000);
                EmpleadoCN.Editar(emple);
                return Json(new { ok = true, toRedirect = Url.Action("Index", "Empleado") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult Detalles(int id)
        {
            return View(EmpleadoCN.Detalles(id));
        }

        [HttpPost]
        public ActionResult Eliminar(int id)
        {
            try
            {

                EmpleadoCN.Eliminar(id);
                return Json(new { ok = true, data = Url.Action("Index","Empleado") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, msg = "Problema en el proceso " + ex.Message }, JsonRequestBehavior.AllowGet);

            }


        }
        public JsonResult ObtenerEmpleados()
        {
            try
            {
                var d = EmpleadoCN.ListaEmpleados();
                return Json(new { data = d }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message }, JsonRequestBehavior.AllowGet);
               
            }
            
        }
        public ActionResult ReporteEmpleado() 
        {
            return View();
        }
        public ActionResult DescargarReporteEmpleado() 
        {
            try
            {
                var reportE = new ReportClass();
                reportE.FileName = Server.MapPath("/Reports/EmpleadoOLE_DBReport.rpt");
                reportE.Load();
                //report connection
                var connInfo = CrystalReportsCnn.GetConnectionInfo();
                TableLogOnInfo logonInfo = new TableLogOnInfo();
                Tables tables;
                tables = reportE.Database.Tables;
                foreach (Table table in tables)
                {
                    logonInfo = table.LogOnInfo;
                    logonInfo.ConnectionInfo = connInfo;
                    table.ApplyLogOnInfo(logonInfo);
                }
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                //pdf
                Stream reportStream = reportE.ExportToStream(ExportFormatType.PortableDocFormat);
                reportE.Dispose();
                reportE.Close();
                return new FileStreamResult(reportStream, "application/pdf ");

                //Exel
                //Stream reportStream = reportE.ExportToStream(ExportFormatType.Excel);
                //reportStream.Seek(0, SeekOrigin.Begin);
                //return  File(reportStream, "application/vnd.ms-exel","Empleados.xls");
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
        public ActionResult MostrarReporteEmpleado()
        {
            //var reportE = new ReportClass();
            //reportE.FileName();
            return View();
        }
    }
}
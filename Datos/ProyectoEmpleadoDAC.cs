using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ProyectoEmpleadoDAC
    {
        public void AsignarProyectos(int EmpleadoId, int ProyectoId)
        {
            using (var db = new ProyectosDBEntities())
            {
                var proyEmpl = new ProyectoEmpleado
                {
                    EmpleadoId = EmpleadoId,
                    ProyectoId = ProyectoId,
                    FechaAlta = DateTime.Now
                };
                db.ProyectoEmpleado.Add(proyEmpl);
                db.SaveChanges();
            }
        }

        public void EliminarAsignacion(int empleadoId, int proyectoId)
        {
            using (var db = new ProyectosDBEntities())
            {
                var proyEmpl = db.ProyectoEmpleado.Where(a => (a.EmpleadoId == empleadoId) && (a.ProyectoId == proyectoId)).FirstOrDefault();
                               
                db.ProyectoEmpleado.Remove(proyEmpl);
                db.SaveChanges();
            }
        }

        public List<VMProyectoEmpleado> GetAsignados()
        {
            using (var db = new ProyectosDBEntities())
            {
                List<VMProyectoEmpleado> list = (from a in db.ProyectoEmpleado
                                                 join p in db.Proyecto on a.ProyectoId equals p.ProyectoId
                                                 join e in db.Empleado on a.EmpleadoId equals e.EmpleadoId
                                                 select new VMProyectoEmpleado
                                                 {
                                                     ProyectoId=a.ProyectoId,
                                                     EmpleadoId=a.EmpleadoId,
                                                     FechaAlta=a.FechaAlta,
                                                     NombreEmpleado=e.Nombres+" "+e.Apellidos,
                                                     NombreProyecto=p.NombreProyecto
                                                 }).ToList();
                return list;
               
            }
        }
        public List<VMProyectoEmpleado> GetAsignados(int EmpleadoId, int ProyectoId)
        {
            using (var db = new ProyectosDBEntities())
            {
                List<VMProyectoEmpleado> list = (from a in db.ProyectoEmpleado
                                                 join p in db.Proyecto on a.ProyectoId equals p.ProyectoId
                                                 join e in db.Empleado on a.EmpleadoId equals e.EmpleadoId
                                                 where(a.EmpleadoId==EmpleadoId && a.ProyectoId==ProyectoId)
                                                 select new VMProyectoEmpleado
                                                 {
                                                     ProyectoId = a.ProyectoId,
                                                     EmpleadoId = a.EmpleadoId,
                                                     FechaAlta = a.FechaAlta,
                                                     NombreEmpleado = e.Nombres + " " + e.Apellidos,
                                                     NombreProyecto = p.NombreProyecto
                                                 }).ToList();
                return list;

            }
        }
    }
}

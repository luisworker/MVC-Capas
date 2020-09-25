using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class EmpleadoDAC
    {
        public List<VMEmpleado> ListaEmpleados()
        {
            using (var db = new ProyectosDBEntities())
            {
                var a = (from e in db.Empleado
                         join p in db.Departamento on e.DepartamentoId equals p.DepartamentoId
                         select new VMEmpleado
                         {
                             EmpleadoId = e.EmpleadoId,
                             Nombres = e.Nombres,
                             Apellidos = e.Apellidos,
                             Email = e.Email,
                             Celular = e.Celular,
                             Direccion = e.Direccion,
                             NombreDepartamento = p.NombreDepartamento
                         }).ToList();


                return a;
            }
        }
        public void Crear(Empleado emple)
        {
            using (var db = new ProyectosDBEntities())
            {
                db.Empleado.Add(emple);
                db.SaveChanges();
            }
        }
        public void Eliminar(int id)
        {
            using (var db = new ProyectosDBEntities())
            {
                Empleado a = db.Empleado.Find(id);
                db.Empleado.Remove(a);
                db.SaveChanges();

            }
        }
        public void Editar(VMEmpleado emple)
        {
            using (var db = new ProyectosDBEntities())
            {
                Empleado nuevo = db.Empleado.Find(emple.EmpleadoId);
                nuevo.Nombres = emple.Nombres;
                nuevo.Apellidos = emple.Apellidos;
                nuevo.Email = emple.Email;
                nuevo.Direccion = emple.Direccion;
                nuevo.Celular = emple.Celular;
                nuevo.DepartamentoId = emple.DepartamentoId;
                
               db.SaveChanges();
            }

        }
        public VMEmpleado Detalles(int id)
        {
            VMEmpleado a;
            using (var db = new ProyectosDBEntities())
            {
                 a = (from e in db.Empleado
                         join p in db.Departamento on e.DepartamentoId equals p.DepartamentoId
                         where e.EmpleadoId==id
                         select new VMEmpleado
                         {
                             EmpleadoId = e.EmpleadoId,
                             Nombres = e.Nombres,
                             Apellidos = e.Apellidos,
                             Email = e.Email,
                             Celular = e.Celular,
                             Direccion = e.Direccion,
                             DepartamentoId=e.DepartamentoId,
                             NombreDepartamento = p.NombreDepartamento
                         }).FirstOrDefault();

            }
            return a;
        }

    }
}

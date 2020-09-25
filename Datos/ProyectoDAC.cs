using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ProyectoDAC
    {
        public List<Proyecto> ListaProyectos()
        {
            using (var db = new ProyectosDBEntities())
            {
                return db.Proyecto.ToList();
            }
        }
        public List<Proyecto> ListaProyectosJson()
        {
            using (var db = new ProyectosDBEntities())
            {
                db.Configuration.LazyLoadingEnabled = false;
                return db.Proyecto.ToList();
            }
        }
        public void Crear(Proyecto proy)
        {
            using (var db = new ProyectosDBEntities())
            {
                db.Proyecto.Add(proy);
                db.SaveChanges();
            }
        }
        public void Eliminar(int id)
        {
            using (var db = new ProyectosDBEntities())
            {
                Proyecto a=db.Proyecto.Find(id);
                db.Proyecto.Remove(a);
                db.SaveChanges();

            }
        }
        public void Editar(Proyecto proy)
        {
            using (var db = new ProyectosDBEntities())
            {
                Proyecto nuevo = db.Proyecto.Find(proy.ProyectoId);
                nuevo.NombreProyecto = proy.NombreProyecto;
                nuevo.FechaInicio = proy.FechaInicio;
                nuevo.FechaFin = proy.FechaFin;
                
                db.SaveChanges();
            }

        }
        public Proyecto Detalles(int id)
        {
            Proyecto a;
            using (var db = new ProyectosDBEntities())
            {
                a = db.Proyecto.Find(id);

            }
            return a;
        }
    }
}

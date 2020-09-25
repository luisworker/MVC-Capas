using Entidad;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DepartamentoDAC
    {
        public List<Departamento> ListaDepartamentos() { 
            using(var db=new ProyectosDBEntities())
	        {
                db.Configuration.LazyLoadingEnabled=false;
                return db.Departamento.ToList();
	        }
        }
        public void Crear(Departamento dpto) 
        {
           
                using (var db=new ProyectosDBEntities())
                {
                    db.Departamento.Add(dpto);
                    db.SaveChanges();
                }
           
        }

        public void Editar(Departamento dpto)
        {

            using (var db = new ProyectosDBEntities())
            {
                var a=db.Departamento.Find(dpto.DepartamentoId);
                a.NombreDepartamento = dpto.NombreDepartamento;
                db.SaveChanges();
            }

        }

        public Departamento Detalles( int id)
        {
            using (var db=new ProyectosDBEntities())
            {
                return db.Departamento.Find(id);
            }
        }

        public void Eliminar(int id)
        {
            using (var db = new ProyectosDBEntities())
            {
                Departamento dpto =db.Departamento.Find(id);
                db.Departamento.Remove(dpto);
                db.SaveChanges();
            }

        }
    }
}

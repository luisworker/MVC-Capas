using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class DepartamentoCN
    {
        private static DepartamentoDAC obj = new DepartamentoDAC();
        public static List<Departamento> ListaDepartamentos() 
        {
            return obj.ListaDepartamentos();
        }
        public static void Crear(Departamento dpto)
        {
            obj.Crear(dpto);
        }
        public static void Edit(Departamento dpto)
        {
            obj.Editar(dpto);
        }
        public static void Eliminar(int id)
        {
            obj.Eliminar(id);
        }

        public static Departamento Detalles(int id)
        {
            return obj.Detalles( id);
        }
    }
}

using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ProyectoCN
    {
        private static ProyectoDAC obj = new ProyectoDAC();
        public static List<Proyecto> ListaProyectos()
        {
            return obj.ListaProyectos();
        }
        public static List<Proyecto> ListaProyectosJson()
        {
            return obj.ListaProyectosJson();
        }
        public static void Crear(Proyecto proy)
        {
            obj.Crear(proy);
        }
        public static void Eliminar(int id) 
        {
            obj.Eliminar(id);
        }
        public static void Editar(Proyecto proy)
        {
            obj.Editar(proy);
        }
        public static Proyecto Detalles(int id)
        {
            return obj.Detalles(id);
        }
    }
}

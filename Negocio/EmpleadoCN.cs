using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EmpleadoCN
    {
        private static EmpleadoDAC obj = new EmpleadoDAC();
        public static List<Entidad.VMEmpleado> ListaEmpleados()
        {
            return obj.ListaEmpleados();
        }
        public static void Crear(Empleado Emple)
        {
            obj.Crear(Emple);

        }
        public static void Eliminar(int id)
        {
            obj.Eliminar(id);
        }
        public static void Editar(VMEmpleado Emple)
        {
            obj.Editar(Emple);
        }
        public static VMEmpleado Detalles(int id)
        {
            return obj.Detalles(id);
        }
    }
}

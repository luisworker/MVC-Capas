using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ProyectoEmpleadoCN
    {
        private static ProyectoEmpleadoDAC obj = new ProyectoEmpleadoDAC();
        public static void AsignarProyecto(int EmpleadoId, int ProyectoId)
        {
            obj.AsignarProyectos(EmpleadoId, ProyectoId);
        }
        public static List<VMProyectoEmpleado> GetAsignados()
        {
            return obj.GetAsignados();
        }

        public static void EliminarAsignacion(int EmpleadoId, int ProyectoId)
        {
            obj.EliminarAsignacion(EmpleadoId, ProyectoId);
        }
        public static bool ExisteAsignacion(int EmpleadoId, int ProyectoId)
        {
            if (obj.GetAsignados(EmpleadoId, ProyectoId).Count>0)
            {
                return true;
            }
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class VMProyectoEmpleado
    {
        public int ProyectoId { get; set; }
        public int EmpleadoId { get; set; }
        public Nullable<System.DateTime> FechaAlta { get; set; }
        public string  NombreProyecto { get; set; }
        public string NombreEmpleado { get; set; }
    }
}

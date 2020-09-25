using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class VMEmpleado
    {
        public int EmpleadoId { get; set; }
        public string Nombres { get; set; }
        
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }
        public string NombreApellidos { get { return $"{Nombres} {Apellidos}"; } }
        public string NombreDepartamento { get; set; }
        public int DepartamentoId { get; set; }
        public int ProyectoId { get; set; }
    }
    

}

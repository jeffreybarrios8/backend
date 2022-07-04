using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
     public class Empleado: Persona
    {
        public int IdEmpleado { get; set; }
        public int Privilegio { get; set; }
     
        public string IdEstadoEmpleado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}

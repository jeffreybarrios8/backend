using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class EmpleadoResponse: Persona
    {
        public int idEmpleado { get; set; }
        public int privilegio { get; set; }
        public string IdEstadoEmpleado { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Reservacion
    {

        public int IdReservacion { get; set; }
        public int IdCliente { get; set; }
        public string IdPago { get; set; }
        public string IdEstadoReservacion { get; set; }
        public DateTime FechaAgendada { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class ReservacionResponse
    {
        public int IdReservacion { get; set; }
        public int IdCliente { get; set; }
        public string idPago { get; set; }
        public string IdEstadoReservacion { get; set; }
        public string PrimerNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string Celular { get; set; }
        public string MetodoPago { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaAgendada { get; set; }


    }
}

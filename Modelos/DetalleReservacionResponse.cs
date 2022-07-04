using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos
{
    public  class DetalleReservacionResponse
    {
        public int IdDetalleReservacion { get; set; }
        public int IdReservacion { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidoEmpleado { get; set; }
        public string NombreServicio { get; set; }
        public float Precio { get; set; }
        public int Duracion { get; set; }
        public string Celular { get; set; }
        public string IdPago { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaAgendada { get; set; }
        public string IdEstadoReservacion { get; set; }
        public string Mes { get; set; }
        public string Dia { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace LogicInterface
{
   public  interface IReservacion
    {
        public IEnumerable<Modelos.ReservacionResponse> ListarReservacion();
        public void AgregarReservacion(Modelos.Reservacion reservacion);
        public void EliminarReservacion(Modelos.Reservacion reservacion);
        public void ActualizarReservacion(Modelos.Reservacion reservacion);
    }
}

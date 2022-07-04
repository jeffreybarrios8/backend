using DataAccessInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Reservacion : LogicInterface.IReservacion
    {
        private readonly DataAccessInterface.IReservacion reservaciones;

        public Reservacion(IReservacion reservaciones)
        {
            this.reservaciones = reservaciones;
        }

        public void ActualizarReservacion(Modelos.Reservacion reservacion)
        {
            reservaciones.ActualizarReservacion(reservacion);
        }

        public void AgregarReservacion(Modelos.Reservacion reservacion)
        {
            reservaciones.AgregarReservacion(reservacion);
        }

        public void EliminarReservacion(Modelos.Reservacion reservacion)
        {
            reservaciones.EliminarReservacion(reservacion);
        }

        public IEnumerable<Modelos.ReservacionResponse> ListarReservacion()
        {
         return reservaciones.ListarReservacion();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessInterface
{
    public interface IDetalleReservacion
    {
        public IEnumerable<Modelos.DetalleReservacionResponse> ListarDetalleReservacion();
        public IEnumerable<Modelos.DetalleReservacionResponse> ListarDetalleReservacionFinalizada();
        public void AgregarDetalleReservacion(Modelos.DetalleReservacion reservacion);
        public void EliminarDetalleReservacion(Modelos.DetalleReservacion reservacion);
        public void ActualizarDetalleReservacion(Modelos.DetalleReservacion reservacion);
    }
}

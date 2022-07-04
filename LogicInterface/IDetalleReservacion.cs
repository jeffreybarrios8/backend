using System;
using System.Collections.Generic;
using System.Text;

namespace LogicInterface
{
     public interface IDetalleReservacion
    {
        public IEnumerable<Modelos.DetalleReservacionResponse> ListarDetalleReservacion();
        public void AgregarDetalleReservacion(Modelos.DetalleReservacion reservacion);
        public void EliminarDetalleReservacion(Modelos.DetalleReservacion reservacion);
        public void ActualizarDetalleReservacion(Modelos.DetalleReservacion reservacion);
        public IEnumerable<Modelos.DetalleReservacionResponse> ListarDetalleReservacionFinalizada();
    }
}

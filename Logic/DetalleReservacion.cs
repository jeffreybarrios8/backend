using DataAccessInterface;
using Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class DetalleReservacion : LogicInterface.IDetalleReservacion
    {
       private readonly DataAccessInterface.IDetalleReservacion detalleReservacion;

        public DetalleReservacion(IDetalleReservacion detalleReservacion)
        {
            this.detalleReservacion = detalleReservacion;
        }

        public void ActualizarDetalleReservacion(Modelos.DetalleReservacion reservacion)
        {
            throw new NotImplementedException();
        }

        public void AgregarDetalleReservacion(Modelos.DetalleReservacion reservacion)
        {
            detalleReservacion.AgregarDetalleReservacion(reservacion);
        }

        public void EliminarDetalleReservacion(Modelos.DetalleReservacion reservacion)
        {
            detalleReservacion.EliminarDetalleReservacion(reservacion);
        }

        public IEnumerable<DetalleReservacionResponse> ListarDetalleReservacion()
        {
           return detalleReservacion.ListarDetalleReservacion();
        }

        public IEnumerable<DetalleReservacionResponse> ListarDetalleReservacionFinalizada()
        {
            return detalleReservacion.ListarDetalleReservacionFinalizada();
        }
    }
}

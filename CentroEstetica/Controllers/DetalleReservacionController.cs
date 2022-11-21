using LogicInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentroEstetica.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Produces("application/json")]
    public class DetalleReservacionController : Controller
    {

        private readonly LogicInterface.IDetalleReservacion detalleReservacion;

        public DetalleReservacionController(IDetalleReservacion detalleReservacion)
        {
            this.detalleReservacion = detalleReservacion;
        }

        [HttpPost]
        public void AgregarDetalleReservacion([FromBody] Modelos.DetalleReservacion reservacion)
        {

            detalleReservacion.AgregarDetalleReservacion(reservacion);
        }

        [HttpPost]
        public void EliminarDetalleReservacion([FromBody] Modelos.DetalleReservacion reservacion)
        {
            detalleReservacion.EliminarDetalleReservacion(reservacion);

        }

        [HttpGet]
        public IEnumerable<Modelos.DetalleReservacionResponse> ListarDetalleReservacion()
        {
            return detalleReservacion.ListarDetalleReservacion();
        }

        [HttpGet]
        public IEnumerable<Modelos.DetalleReservacionResponse> ListarDetalleReservacionFinalizada()
        {
            return detalleReservacion.ListarDetalleReservacionFinalizada();
        }



    }
}

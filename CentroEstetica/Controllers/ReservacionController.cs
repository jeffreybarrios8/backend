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
    public class ReservacionController : Controller
    {
        private readonly LogicInterface.IReservacion reservaciones;

        public ReservacionController(IReservacion reservaciones)
        {
            this.reservaciones = reservaciones;
        }


        [HttpPost]
        public void AgregarReservacion([FromBody] Modelos.Reservacion reservacion)
        {

            reservaciones.AgregarReservacion(reservacion);
        }

        [HttpPost]
        public void EliminarReservacion([FromBody] Modelos.Reservacion reservacion)
        {
            reservaciones.EliminarReservacion(reservacion);

        }

        [HttpGet]
        public IEnumerable<Modelos.ReservacionResponse> ListarReservacion()
        {
          return  reservaciones.ListarReservacion();
        }

        [HttpPost]
        public void ActualizarReservacion([FromBody] Modelos.Reservacion reservacion)
        {
            reservaciones.ActualizarReservacion(reservacion);
        }


    }
}

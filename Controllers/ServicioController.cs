using DataAccessInterface;
using Gmg.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentroEstetica.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Produces("application/json")]
    public class ServicioController : Controller
    {

        private readonly LogicInterface.IServicios servicios;
      
     

        public ServicioController(LogicInterface.IServicios servicios)
        {
            this.servicios = servicios;
          
        }

        [HttpGet]
        public IEnumerable<Modelos.Servicios> ListarServicios()
        {

            try
            {    
                return servicios.ListarServicios();
            }
            catch (Exception)
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
                return null;
            }
                   
        }

       [HttpPost]
       public void AgregarServicio([FromBody] Modelos.Servicios servicio)
        {
            servicios.AgregarServicio(servicio);

        }

        [HttpPost]
        public void EliminarServicio([FromBody] Modelos.Servicios servicio)
        {
            servicios.EliminarServicio(servicio);

        }

        [HttpPost]
        public void ActualizarServicio([FromBody] Modelos.Servicios servicio)
        {
            servicios.ActualizarServicio(servicio);

        }



    }
}

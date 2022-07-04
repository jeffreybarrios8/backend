using Gmg.Common;
using LogicInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentroEstetica.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Produces("application/json")]
    public class EmpleadoController : Controller
    {
        private readonly LogicInterface.IEmpleado empleados;
    

        public EmpleadoController(LogicInterface.IEmpleado empleado)
        {
            this.empleados = empleado;
           

        }

        [HttpPost]
        public void AgregarEmpleado([FromBody] Modelos.Empleado empleado)
        {
            try
            { 
                empleados.AgregarEmpleado(empleado);
            }
            catch (Exception)
            {

               Response.StatusCode = StatusCodes.Status500InternalServerError;
               

            }
           
        }

        [HttpPost]
        public void EliminarEmpleado([FromBody] Modelos.Empleado empleado)
        { 
            empleados.EliminarEmpleado(empleado);
           
        }

        [HttpGet]
        public IEnumerable<Modelos.EmpleadoResponse> ListarEmpleado()
        {
            var resultado = empleados.ListarEmpleados();
            return resultado;
        }

        [HttpPost]
        public void ActualizarEmpleado([FromBody] Modelos.Empleado empleado)
        {
            empleados.ActualizarEmpleado(empleado);
        }

    }
}

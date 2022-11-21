using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentroEstetica.Controllers
{
    [Route("[controller]/[action]")]
    [Produces("application/json")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly LogicInterface.ICliente clientes;

        public ClienteController(LogicInterface.ICliente cliente)
        {
            this.clientes = cliente;
        }

        [HttpGet]
        public IEnumerable<Modelos.Cliente> ListarCliente()
        {
            return clientes.ListarCliente();
        }

        [HttpPost]
        public void AgregarCliente(Modelos.Cliente cliente)
        {
            clientes.AgregarCliente(cliente);
        }

        [HttpPost]
        public void EliminarCliente(Modelos.Cliente cliente)
        {
            clientes.EliminarCliente(cliente);
        }

        [HttpPost]
        public void ActualizarCliente(Modelos.Cliente cliente)
        {
            clientes.ActualizarCliente(cliente);
        }


    }


}

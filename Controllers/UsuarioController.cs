using BusinessLogicInterface;
using Gmg.Common;
using Gmg.Common.Core.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CentroEstetica.Controllers
{
    [Route("[controller]/[action]")]
    [Produces("application/json")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly BusinessLogicInterface.IUsuario usuario;

        public UsuarioController(IUsuario usuario)
        {
            this.usuario = usuario;
        }

        [HttpGet]
        public IEnumerable<Modelos.User> ListarUsuario()
        {
            return usuario.ListarUsuario();
        }

        [HttpPost]
        public void AgregarUsuario(Modelos.User user)
        {
            usuario.AgregaUsuario(user);
        }

        [HttpPost]
        public void EliminarUsuario(Modelos.User user)
        {
            usuario.EliminarUsuario(user);
        }

        [HttpPost]
        public void ActualizarUsuario(Modelos.User user)
        {
            usuario.ActualizarUsuario(user);
        }

        [HttpPost]
        public  Task<Response> Login([FromBody] Modelos.User user)
        {
           return usuario.Login(user);
         
        }
    }
}

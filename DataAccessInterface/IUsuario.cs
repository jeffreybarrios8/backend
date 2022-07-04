using Gmg.Common;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace DataAccessInterface
{
    public interface IUsuario
    {
        public IEnumerable<Modelos.User> ListarUsuario();
        public void AgregaUsuario(Modelos.User user);
        public void EliminarUsuario(Modelos.User user);
        public void ActualizarUsuario(Modelos.User user);

        public Task<Response> Login(Modelos.User user);
    }
}

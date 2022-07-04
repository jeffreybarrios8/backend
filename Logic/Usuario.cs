using DataAccessInterface;
using Gmg.Common;
using Modelos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace BusinessLogic
{
    public class Usuario : BusinessLogicInterface.IUsuario
    {
        private readonly DataAccessInterface.IUsuario usuario;

        public Usuario(IUsuario usuario)
        {
            this.usuario = usuario;
        }

        public void ActualizarUsuario(User user)
        {
            usuario.ActualizarUsuario(user);
        }

        public void AgregaUsuario(User user)
        {
            usuario.AgregaUsuario(user);
        }

        public void EliminarUsuario(User user)
        {
            usuario.EliminarUsuario(user);
        }

        public IEnumerable<User> ListarUsuario()
        {
            return usuario.ListarUsuario();
        }

    

        public Task<Response> Login(User user)
        {
           return  usuario.Login(user);
        }
    }
}

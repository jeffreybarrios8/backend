using Dapper;
using Gmg.Common;
using Microsoft.Extensions.Configuration;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace DataAccess
{
    public class Usuario : DataAccessInterface.IUsuario
    {

        private readonly IConfiguration _config;

        public Usuario(IConfiguration config)
        {
            _config = config;
        }

        public void ActualizarUsuario(User user)
        {
            using IDbConnection dBConnection = new SqlConnection(_config.GetConnectionString("MiConexion"));
            dBConnection.Open();
            var p = new DynamicParameters();
            p.Add("@IdRegistrarUsuario", user.IdRegistrarUsuario);
            p.Add("@Contraseña ", user.Contraseña);
            dBConnection.Query<Modelos.User>(
                sql: "ActualizarUsuario",
                p,
                commandType: CommandType.StoredProcedure
                );
        }

        public void AgregaUsuario(User user)
        {
            using IDbConnection dBConnection = new SqlConnection(_config.GetConnectionString("MiConexion"));
            dBConnection.Open();
            var p = new DynamicParameters();
            p.Add("@Nombre", user.Nombre);
            p.Add("@Apellido", user.Apellido);
            p.Add("@Usuario ", user.Usuario);
            p.Add("@Contraseña ", user.Contraseña);
            p.Add("@Privilegio ", user.Privilegio);
            dBConnection.Query<Modelos.User>(
                sql: "sp_RegistrarUsuario",
                p,
                commandType: CommandType.StoredProcedure
                );
        }

        public void EliminarUsuario(User user)
        {
            using IDbConnection dBConnection = new SqlConnection(_config.GetConnectionString("MiConexion"));
            dBConnection.Open();
            var p = new DynamicParameters();
            p.Add("@IdRegistrarUsuario", user.IdRegistrarUsuario);
            dBConnection.Query<Modelos.User>(
                sql: "sp_EliminarUsuario",
                p,
                commandType: CommandType.StoredProcedure
                );
        }

        public IEnumerable<User> ListarUsuario()
        {
            using IDbConnection dBConnection = new SqlConnection(_config.GetConnectionString("MiConexion"));
            dBConnection.Open();
           var resultado= dBConnection.Query<Modelos.User>(
                sql: "ListarUsuario",
                commandType: CommandType.StoredProcedure
                );

            return resultado;
        }

        public async Task<Response> Login(User user)
        {
            using IDbConnection dBConnection = new SqlConnection(_config.GetConnectionString("MiConexion"));
            dBConnection.Open();
            //var p = new DynamicParameters();
            //p.Add("@Usuario", user.Usuario);
            //p.Add("@Contraseña", user.Contraseña);
            var resultado = dBConnection.QueryMultiple(
                "sp_AccederUsuario",
                param: new
                {
                   user.Usuario,
                   user.Contraseña,
                  
                },
                commandType: CommandType.StoredProcedure
                );

                var codigoError = resultado.ReadFirstOrDefault<int>();
                if (codigoError == -5005)
                {
                   
                    return new Response("Login fallido");
                }

            return new Response("Bienvenido");
        }
    }
}

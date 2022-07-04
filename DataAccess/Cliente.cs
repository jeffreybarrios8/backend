using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Cliente : DataAccessInterface.ICliente
    {
        private readonly IConfiguration _config;

        public Cliente(IConfiguration config)
        {
            _config = config;
        }

        public void ActualizarCliente(Modelos.Cliente cliente)
        {
            using IDbConnection dbConnection =
             new SqlConnection(_config.GetConnectionString("MiConexion"));
            dbConnection.Open();
            var p = new DynamicParameters();
            p.Add("@IdCliente", cliente.IdCliente);
            p.Add("@Celular", cliente.Celular);
            dbConnection.Query<Modelos.Cliente>(
            sql: "sp_ActualizarCliente",
            p,
            commandType: CommandType.StoredProcedure
           );
        }

        public void AgregarCliente(Modelos.Cliente cliente)
        {
            using IDbConnection dbConnection =
            new SqlConnection(_config.GetConnectionString("MiConexion"));
            dbConnection.Open();
            var p = new DynamicParameters();
            p.Add("@PrimerNombre", cliente.PrimerNombre);
            p.Add("@SegundoNombre ", cliente.SegundoNombre);
            p.Add("@PrimerApellido ", cliente.PrimerApellido);
            p.Add("@SegundoApellido  ", cliente.SegundoApellido);
            p.Add("@Celular  ", cliente.Celular);
          
            dbConnection.Query<Modelos.Cliente>(
            sql: "sp_RegistrarCliente",
            p,
            commandType: CommandType.StoredProcedure
           );
        }

        public void EliminarCliente(Modelos.Cliente cliente)
        {
            using IDbConnection dbConnection =
            new SqlConnection(_config.GetConnectionString("MiConexion"));
            dbConnection.Open();
            var p = new DynamicParameters();
            p.Add("@IdCliente", cliente.IdCliente);
           
            dbConnection.Query<Modelos.Cliente>(
            sql: "sp_EliminarCliente",
            p,
            commandType: CommandType.StoredProcedure
           );

        }

        public IEnumerable<Modelos.Cliente> ListarCliente()
        {
            using IDbConnection dbConnection =
            new SqlConnection(_config.GetConnectionString("MiConexion"));
            dbConnection.Open();
            var resultado= dbConnection.Query<Modelos.Cliente>(
            sql: "sp_ListarCliente",
            commandType: CommandType.StoredProcedure
           );
            return resultado;
        }
    }
}

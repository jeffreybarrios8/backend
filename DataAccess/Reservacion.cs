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
    public class Reservacion : DataAccessInterface.IReservacion
    {
        private readonly IConfiguration _config;

        public Reservacion(IConfiguration iconfiguration)
        {
            this._config = iconfiguration;
        }

        public void ActualizarReservacion(Modelos.Reservacion reservacion)
        {
            using IDbConnection dbConnection =
           new SqlConnection(_config.GetConnectionString("MiConexion"));
            dbConnection.Open();
            var p = new DynamicParameters();
            p.Add("@IdReservacion", reservacion.IdReservacion);
            p.Add("@IdPago ", reservacion.IdPago);
            p.Add("@IdEstadoReservacion ", reservacion.IdEstadoReservacion);

            dbConnection.Query<Modelos.Reservacion>(
            sql: "sp_ActualizarReservacion",
            p,
            commandType: CommandType.StoredProcedure
           );
        }

        public void AgregarReservacion(Modelos.Reservacion reservacion)
        {
            using IDbConnection dbConnection =
            new SqlConnection(_config.GetConnectionString("MiConexion"));
            dbConnection.Open();
            var p = new DynamicParameters();
            p.Add("@IdCliente", reservacion.IdCliente);
            p.Add("@IdPago ", reservacion.IdPago);
            p.Add("@IdEstadoReservacion ", reservacion.IdEstadoReservacion);
            p.Add("@FechaAgendada  ", reservacion.FechaAgendada);
           
            dbConnection.Query<Modelos.Reservacion>(
            sql: "sp_RegistrarReservacion",
            p,
            commandType: CommandType.StoredProcedure
           );
        }

        public void EliminarReservacion(Modelos.Reservacion reservacion)
        {
            using IDbConnection dbConnection =
            new SqlConnection(_config.GetConnectionString("MiConexion"));
            dbConnection.Open();
            var p = new DynamicParameters();
            p.Add("@IdReservacion", reservacion.IdReservacion);
          
            dbConnection.Query<Modelos.Reservacion>(
            sql: "sp_EliminarReservacion",
            p,
            commandType: CommandType.StoredProcedure
           );
        }

        public IEnumerable<Modelos.ReservacionResponse> ListarReservacion()
        {
            using IDbConnection dbConnection =
            new SqlConnection(_config.GetConnectionString("MiConexion"));
            dbConnection.Open();
            var resultado= dbConnection.Query<Modelos.ReservacionResponse>(
            sql: "ListarReservacion",
            commandType: CommandType.StoredProcedure
           );
            return resultado;
        }
    }
}

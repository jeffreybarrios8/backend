using Dapper;
using Microsoft.Extensions.Configuration;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess
{
    public class DetalleReservacion : DataAccessInterface.IDetalleReservacion
    {
        private readonly IConfiguration _config;

        public DetalleReservacion(IConfiguration config)
        {
            _config = config;
        }

        public void ActualizarDetalleReservacion(Modelos.DetalleReservacion reservacion)
        {
          
        }

        public void AgregarDetalleReservacion(Modelos.DetalleReservacion reservacion)
        {
            using IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("MiConexion"));
            dbConnection.Open();
            var p =new  DynamicParameters();
            p.Add("@IdEmpleado", reservacion.IdEmpleado);
            p.Add("@IdServicio", reservacion.IdServicio);
            p.Add("@IdReservacion", reservacion.IdReservacion);
            var resultado = dbConnection.Query<Modelos.DetalleReservacion>(
                sql: "sp_AgregarDetalleReservacion",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public void EliminarDetalleReservacion(Modelos.DetalleReservacion reservacion)
        {
            using IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("MiConexion"));
            dbConnection.Open();
            var p = new DynamicParameters();
            p.Add("@IdDetalleReservacion", reservacion.IdDetalleReservacion);
         
            var resultado = dbConnection.Query<Modelos.DetalleReservacion>(
                sql: "sp_EliminarDetalleReservacion",
                p,
                commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<DetalleReservacionResponse> ListarDetalleReservacion()
        {
            using IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("MiConexion"));
            dbConnection.Open();          
            var resultado = dbConnection.Query<Modelos.DetalleReservacionResponse>(
                sql: "sp_ListarDetalleReservacion",               
                commandType: CommandType.StoredProcedure
                ); 
                return resultado;
        }

        public IEnumerable<DetalleReservacionResponse> ListarDetalleReservacionFinalizada()
        {
            using IDbConnection dbConnection = new SqlConnection(_config.GetConnectionString("MiConexion"));
            dbConnection.Open();
            var resultado = dbConnection.Query<Modelos.DetalleReservacionResponse>(
                sql: "sp_ListarDetalleReservacionFinalizada",
                commandType: CommandType.StoredProcedure
                );
            return resultado;
        }
    }
}

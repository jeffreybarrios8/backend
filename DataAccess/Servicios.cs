using Dapper;
using DataAccessInterface;
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
    public class Servicios: IServicios
    {

        private readonly IConfiguration _config;


        public Servicios(IConfiguration _config)
        {
            this._config = _config;
        }

        public void ActualizarServicio(Modelos.Servicios servicio)
        {
            using IDbConnection dBConnection = new SqlConnection(_config.GetConnectionString("MiConexion"));
            dBConnection.Open();
            var p = new DynamicParameters();
            p.Add("@IdServicio", servicio.IdServicio);
            p.Add("@NombreServicio", servicio.NombreServicio);
            p.Add("@Precio ", servicio.Precio);
            p.Add("@Duracion ", servicio.Duracion);
            dBConnection.Query<Modelos.Servicios>(
                sql: "sp_ActualizarServicio",
                p,
                commandType: CommandType.StoredProcedure
                );
        }

        
      

        public void AgregarServicio(Modelos.Servicios servicio)
        {
            using IDbConnection dbConnection =
            new SqlConnection(_config.GetConnectionString("MiConexion"));
            dbConnection.Open();
            var p = new DynamicParameters();
            p.Add("@NombreServicio", servicio.NombreServicio);
            p.Add("@Precio ", servicio.Precio);
            p.Add("@Duracion ", servicio.Duracion);
           
            dbConnection.Query<Modelos.Servicios>(
            sql: "sp_AgregarServicio",
            p,
            commandType: CommandType.StoredProcedure
           );
        }

        public void EliminarServicio(Modelos.Servicios servicio)
        {
            using IDbConnection dBConnection = new SqlConnection(_config.GetConnectionString("MiConexion"));
            dBConnection.Open();
            var p = new DynamicParameters();
            p.Add("@IdServicio", servicio.IdServicio);
            dBConnection.Query<Modelos.Servicios>(
                sql: "sp_EliminarServicio",
                p,
                commandType: CommandType.StoredProcedure
                );
        }

        public  IEnumerable<Modelos.Servicios> ListarServicios()
        {
            
           IEnumerable <Modelos.Servicios> resultado;
           using IDbConnection dbConnection =
           new SqlConnection(_config.GetConnectionString("MiConexion"));
           dbConnection.Open();
           resultado = dbConnection.Query<Modelos.Servicios>(
           sql: "sp_ListarServicios",
           commandType: CommandType.StoredProcedure
           );

            return resultado;

        }
    }
}


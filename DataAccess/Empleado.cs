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
    public class Empleado:IEmpleado
    {

        private readonly IConfiguration _config;

        public Empleado(IConfiguration config)
        {
            _config = config;
        }

        public void ActualizarEmpleado(Modelos.Empleado empleado)
        {
            using IDbConnection dBConnection = new SqlConnection(_config.GetConnectionString("MiConexion"));
            dBConnection.Open();
            var p = new DynamicParameters();
            p.Add("@IdEmpleado", empleado.IdEmpleado);
            p.Add("@Direccion  ", empleado.Direccion);
            p.Add("@Celular  ", empleado.Celular);
            p.Add("@privilegio  ", empleado.Privilegio);
            p.Add("@IdEstadoEmpleado  ", empleado.IdEstadoEmpleado);
            dBConnection.Query<Modelos.Empleado>(
                sql: "sp_ActualizarEmpleado",
                p,
                commandType: CommandType.StoredProcedure
                );
        }

        public void AgregarEmpleado(Modelos.Empleado empleado)
        {
            using IDbConnection dbConnection =
            new SqlConnection(_config.GetConnectionString("MiConexion"));
            dbConnection.Open();
            var p = new DynamicParameters();
            p.Add("@PrimerNombre", empleado.PrimerNombre);
            p.Add("@SegundoNombre ", empleado.SegundoNombre);
            p.Add("@PrimerApellido ", empleado.PrimerApellido);
            p.Add("@SegundoApellido  ", empleado.SegundoApellido);
            p.Add("@Direccion  ", empleado.Direccion);
            p.Add("@Cedula  ", empleado.Cedula);
            p.Add("@Celular  ", empleado.Celular);
            p.Add("@privilegio  ", empleado.Privilegio);
            p.Add("@IdEstadoEmpleado  ", empleado.IdEstadoEmpleado);
            dbConnection.Query<Modelos.Empleado>(            
            sql: "sp_RegistrarEmpleado",
            p,
            commandType: CommandType.StoredProcedure
           );
        }

        public void EliminarEmpleado(Modelos.Empleado empleado)
        {
            using IDbConnection dbConnection =
            new SqlConnection(_config.GetConnectionString("MiConexion"));
            dbConnection.Open();
            var p = new DynamicParameters();
            p.Add("@IdEmpleado  ", empleado.IdEmpleado);
            dbConnection.Query<Modelos.Empleado>(
                sql: "sp_EliminarEmpleado",
                p,
                commandType: CommandType.StoredProcedure
                );
        }

        public IEnumerable<Modelos.EmpleadoResponse> ListarEmpleados()
        {
           using IDbConnection dbConnection =
           new SqlConnection(_config.GetConnectionString("MiConexion"));
            dbConnection.Open();
           var resultado= dbConnection.Query<Modelos.EmpleadoResponse>(
            sql: "sp_ListarEmpleado",
            commandType: CommandType.StoredProcedure
           );
            return resultado;
        }
    }
}

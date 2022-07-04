using System;
using System.Data;
using System.Data.SqlClient;
using DataAccessInterface;
using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    public class ConnectionManager: IConnectionManager
    {

        public const string BD_key = "MongeLabs";
        private readonly IConfiguration configuration = null;

        public ConnectionManager (IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public IDbConnection GetConnection(string key)
        { 
            return new SqlConnection(ConfigurationExtensions.GetConnectionString(configuration,key));
        }
    }
}

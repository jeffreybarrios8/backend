using System;
using System.Data;

namespace DataAccessInterface
{
   

        public interface IConnectionManager
        {
            IDbConnection GetConnection(string key);
        }
    
}

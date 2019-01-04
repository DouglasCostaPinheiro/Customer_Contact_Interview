using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Infra
{
    public abstract class Repository
    {
        protected SqlConnection _conn = new SqlConnection();

        public Repository()
        {
            _conn.ConnectionString = ConfigurationManager.ConnectionStrings["SQL"].ConnectionString;
        }
    }
}

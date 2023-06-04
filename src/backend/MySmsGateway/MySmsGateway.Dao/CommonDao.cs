using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmsGateway.Dao
{
    public class CommonDao
    {
        protected const string DB_CONNECTION_STRING_KEY = "AppDbConnectionString";
        protected readonly IConfiguration configuration;
        public CommonDao(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IDbConnection GetDbConnection()
        {
            return new SqlConnection(configuration.GetConnectionString(DB_CONNECTION_STRING_KEY));
        }
    }
}

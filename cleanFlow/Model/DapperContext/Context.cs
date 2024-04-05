using MySql.Data.MySqlClient;
using System.Data;

namespace cleanFlow.Model.DapperContext
{
    public class Context
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("connection");
        }
        public IDbConnection CreateConnection() => new MySqlConnection(_connectionString);
    }
}

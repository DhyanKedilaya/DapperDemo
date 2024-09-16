using Npgsql;
using System.Data;

namespace DapperDemo.Data
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection()
            => new NpgsqlConnection(_connectionString);

        //IDbConnection is used to connect to the database(connection string defines this) using dapper.
    }
}

using Microsoft.Data.SqlClient;
using System.Data;

namespace Simposium2023.Data
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection CreateConnection(string connectionName) =>
            new SqlConnection(_configuration[$"connectionStrings:{connectionName}"]);
    }
}

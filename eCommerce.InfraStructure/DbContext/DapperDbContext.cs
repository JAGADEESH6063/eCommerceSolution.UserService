using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.InfraStructure.DbContext
{
    public class DapperDbContext
    {
        private readonly IDbConnection _dbConnection;
        private readonly IConfiguration _configuration;
        public DapperDbContext(IConfiguration configuration)
        {
            _configuration = configuration;

            string? ConnectionString = _configuration.GetConnectionString("PostgresConnection");

            _dbConnection = new NpgsqlConnection(ConnectionString);
        }

        public IDbConnection dbConnection => _dbConnection;
    }
}

using System;
using System.Data;
using Npgsql;
using SuggestService.DataAccess.Interfaces;

namespace SuggestService.Configurators.DbConfigurator
{
    public class PostgresConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        public PostgresConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection Create()
        {
            return new NpgsqlConnection(_connectionString);
        }
    }
}

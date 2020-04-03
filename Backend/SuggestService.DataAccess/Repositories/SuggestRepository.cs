using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using SuggestService.DataAccess.Entities;
using SuggestService.DataAccess.Interfaces;

namespace SuggestService.DataAccess.Repositories
{
    public class SuggestRepository : ISuggestRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public SuggestRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IReadOnlyCollection<string>> GetSuggestsAsync(string input, CancellationToken token)
        {
            using (var dbConnection = _connectionFactory.Create())
            {
                dbConnection.Open();
                var suggests = await dbConnection.QueryAsync<SuggestEntity>("SELECT * FROM customer", token);
                return suggests.Select(c => c.Name).ToArray();
            }
        }
    }
}

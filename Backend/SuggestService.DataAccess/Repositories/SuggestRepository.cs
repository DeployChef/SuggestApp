using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using SuggestService.DataAccess.Entities;
using SuggestService.DataAccess.Interfaces;

namespace SuggestService.DataAccess.Repositories
{
    public class SuggestRepository : ISuggestRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        private readonly ILogger<SuggestRepository> _logger;

        public SuggestRepository(IDbConnectionFactory dbConnectionFactory, ILogger<SuggestRepository> logger = null)
        {
            _dbConnectionFactory = dbConnectionFactory;
            _logger = logger ?? new NullLogger<SuggestRepository>();
        }

        public async Task<IReadOnlyCollection<string>> GetSuggestsAsync(string input, CancellationToken token)
        {
            using (var dbConnection = _dbConnectionFactory.Create())
            {
                dbConnection.Open();
                var suggests = await dbConnection.QueryAsync<SuggestEntity>("SELECT * FROM customer", token);
                return suggests.Select(c => c.Name).ToArray();
            }
        }
    }
}

﻿using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using SuggestService.DataAccess.Interfaces;
using SuggestService.DataAccess.Translators;
using SuggestService.Domain.Models;
using SuggestService.Entities;

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

        public async Task<IReadOnlyCollection<Suggest>> GetSuggestsAsync(string input, CancellationToken token)
        {
            _logger.LogTrace($"Getting suggests for {input}");

            using (var dbConnection = _dbConnectionFactory.Create())
            {
                var query = $"SELECT * FROM public.suggest WHERE suggestion ~* '^{input}' LIMIT 10";

                dbConnection.Open();
                var suggests = (await dbConnection.QueryAsync<SuggestEntity>(new CommandDefinition(query, cancellationToken: token))).ToList();

                _logger.LogTrace($"Received {suggests.Count} suggests for {input}");

                return suggests.Select(c => c.ToModel()).ToArray();
            }
        }
    }
}

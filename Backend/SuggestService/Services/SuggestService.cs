using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using SuggestService.Controllers;
using SuggestService.DataAccess.Interfaces;
using SuggestService.Domain.Results;
using SuggestService.Domain.Results.Enums;

namespace SuggestService.Services
{
    public class SuggestService : ISuggestService
    {
        private readonly ISuggestRepository _repository;
        private readonly ILogger<SuggestService> _logger;

        public SuggestService(ISuggestRepository repository, ILogger<SuggestService> logger = null)
        {
            _repository = repository;
            _logger = logger ?? new NullLogger<SuggestService>();
        }

        public async Task<Result<SuggestServiceResult, IReadOnlyCollection<string>>> GetSuggestsAsync(string input, CancellationToken token)
        {
            try
            {
                var result = await _repository.GetSuggestsAsync(input, token);
                _logger.LogInformation($"Received suggest for {input}");

                return new Result<SuggestServiceResult, IReadOnlyCollection<string>>(SuggestServiceResult.Ok, result.Select(c=>c.Suggestion).ToArray());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new Result<SuggestServiceResult, IReadOnlyCollection<string>>(SuggestServiceResult.Error, message: "DB error");
            }
        }
    }
}

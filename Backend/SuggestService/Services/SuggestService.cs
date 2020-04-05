using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using SuggestService.Controllers;
using SuggestService.DataAccess.Interfaces;

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

        public Task<IReadOnlyCollection<string>> GetSuggestsAsync(string input, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}

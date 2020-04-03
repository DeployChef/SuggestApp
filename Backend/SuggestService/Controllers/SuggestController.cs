using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using SuggestService.DataAccess.Interfaces;

namespace SuggestService.Controllers
{
    [ApiController]
    [Route("api/suggest")]
    public class SuggestController : Controller
    {
        private readonly ISuggestRepository _repository;
        private readonly ILogger<SuggestController> _logger;

        public SuggestController(ISuggestRepository repository, ILogger<SuggestController> logger = null)
        {
            _repository = repository;
            _logger = logger ?? new NullLogger<SuggestController>();
        }


        [ActionName("Suggests")]
        [HttpGet("Suggests")]
        public async Task<IActionResult> Suggest(string input, CancellationToken token)
        {
            var result = await _repository.GetSuggestsAsync(input, token);
            _logger.LogInformation($"Getting suggest by {input}");
            return Ok(result);
        }
    }
}

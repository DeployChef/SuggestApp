using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using SuggestService.Domain.Results.Enums;
using SuggestService.Services;

namespace SuggestService.Controllers
{
    [ApiController]
    [Route("api/suggest")]
    public class SuggestController : Controller
    {
        private readonly ISuggestService _suggestService;
        private readonly ILogger<SuggestController> _logger;

        public SuggestController(ISuggestService suggestService, ILogger<SuggestController> logger = null)
        {
            _suggestService = suggestService;
            _logger = logger ?? new NullLogger<SuggestController>();
        }


        [ActionName("Suggests")]
        [HttpGet("Suggests")]
        public async Task<IActionResult> Suggest(string input, CancellationToken token)
        {
            var result = await _suggestService.GetSuggestsAsync(input, token);

            if (result.Value == SuggestServiceResult.Ok)
                return Ok(result.Data);

            _logger.LogWarning($"Conflict {result.Message}");
            return Conflict(result.Message);
        }
    }
}

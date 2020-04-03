using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace SuggestService.Controllers
{
    [ApiController]
    [Route("api/suggest")]
    public class SuggestController : Controller
    {
        private readonly ILogger<SuggestController> _logger;

        public SuggestController(ILogger<SuggestController> logger)
        {
            _logger = logger ?? new NullLogger<SuggestController>();
        }
    }
}

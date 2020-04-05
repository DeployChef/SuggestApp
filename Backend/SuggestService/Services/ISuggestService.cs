using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SuggestService.Domain.Results;
using SuggestService.Domain.Results.Enums;

namespace SuggestService.Services
{
    public interface ISuggestService
    {
        Task<Result<SuggestServiceResult, IReadOnlyCollection<string>>> GetSuggestsAsync(string input, CancellationToken token);
    }
}

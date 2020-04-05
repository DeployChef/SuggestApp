using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SuggestService.Services
{
    public interface ISuggestService
    {
        Task<IReadOnlyCollection<string>> GetSuggestsAsync(string input, CancellationToken token);
    }
}

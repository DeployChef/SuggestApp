using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SuggestService.Domain.Models;

namespace SuggestService.DataAccess.Interfaces
{
    public interface ISuggestRepository
    {
        Task<IReadOnlyCollection<Suggest>> GetSuggestsAsync(string input, CancellationToken token);
    }
}

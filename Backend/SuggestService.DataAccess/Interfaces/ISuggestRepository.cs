using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SuggestService.DataAccess.Interfaces
{
    public interface ISuggestRepository
    {
        Task<IReadOnlyCollection<string>> GetSuggests(string input, CancellationToken token);
    }
}

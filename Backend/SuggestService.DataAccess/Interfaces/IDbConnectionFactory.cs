using System.Data;

namespace SuggestService.DataAccess.Interfaces
{
    public interface IDbConnectionFactory
    {
        IDbConnection Create();
    }
}

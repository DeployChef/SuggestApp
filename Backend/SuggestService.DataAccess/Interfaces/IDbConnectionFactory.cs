using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SuggestService.DataAccess.Interfaces
{
    public interface IDbConnectionFactory
    {
        IDbConnection Create();
    }
}

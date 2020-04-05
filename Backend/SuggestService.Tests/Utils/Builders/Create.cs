using System;
using System.Collections.Generic;
using System.Text;

namespace SuggestService.Tests.Utils.Builders
{
    public static class Create
    {
        public static SuggestServiceBuilder SuggestService() => new SuggestServiceBuilder();
    }
}

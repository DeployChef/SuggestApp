using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace SuggestService.Configurators.DbConfigurator
{
    public static class DbConfiguratorExtension
    {
        public static IServiceCollection UseNpgsqlConnections(this IServiceCollection services, string connectionString)
        {
            services.AddTransient(provider => new PostgresConnectionFactory(connectionString));
            return services;
        }
    }
}

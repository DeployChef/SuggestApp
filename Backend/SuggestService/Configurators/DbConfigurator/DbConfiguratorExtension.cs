using Microsoft.Extensions.DependencyInjection;
using SuggestService.DataAccess.Interfaces;

namespace SuggestService.Configurators.DbConfigurator
{
    public static class DbConfiguratorExtension
    {
        public static IServiceCollection UseNpgsqlConnections(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<IDbConnectionFactory>(provider => new PostgresConnectionFactory(connectionString));
            return services;
        }
    }
}

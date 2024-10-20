using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ModuleMonolith.Common.Application.Clock;
using ModuleMonolith.Common.Infrastructure.Clock;
using ModuleMonolith.Common.Infrastructure.Data;
using ModuleMonolith.Modules.Codes.Application.Abstractions.Data;
using Npgsql;

namespace ModuleMonolith.Common.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string databaseConnectionString)
    {
        var npgsqlDataSource = new NpgsqlDataSourceBuilder(databaseConnectionString).Build();
        services.TryAddSingleton(npgsqlDataSource);

        services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
        services.TryAddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }
}

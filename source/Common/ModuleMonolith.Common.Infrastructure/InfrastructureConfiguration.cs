using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ModuleMonolith.Common.Application.Caching;
using ModuleMonolith.Common.Application.Clock;
using ModuleMonolith.Common.Application.Data;
using ModuleMonolith.Common.Infrastructure.Caching;
using ModuleMonolith.Common.Infrastructure.Clock;
using ModuleMonolith.Common.Infrastructure.Data;
using ModuleMonolith.Common.Infrastructure.Interceptors;
using Npgsql;
using StackExchange.Redis;

namespace ModuleMonolith.Common.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string databaseConnectionString, string redisConnectionString)
    {
        var npgsqlDataSource = new NpgsqlDataSourceBuilder(databaseConnectionString).Build();
        services.TryAddSingleton(npgsqlDataSource);

        services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

        services.AddSingleton<PublishDomainEventsInterceptor>();

        services.TryAddSingleton<IDateTimeProvider, DateTimeProvider>();

        var connectionMultiplexer = ConnectionMultiplexer.Connect(redisConnectionString) as IConnectionMultiplexer;
        services.TryAddSingleton(connectionMultiplexer);

        services.AddStackExchangeRedisCache(options =>
            options.ConnectionMultiplexerFactory = () => Task.FromResult(connectionMultiplexer));

        services.TryAddSingleton<ICacheService, CacheService>();

        return services;
    }
}

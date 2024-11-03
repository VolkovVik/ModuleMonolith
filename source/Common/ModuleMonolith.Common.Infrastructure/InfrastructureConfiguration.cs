using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ModuleMonolith.Common.Application.Caching;
using ModuleMonolith.Common.Application.Clock;
using ModuleMonolith.Common.Application.Data;
using ModuleMonolith.Common.Application.EventBus;
using ModuleMonolith.Common.Infrastructure.Caching;
using ModuleMonolith.Common.Infrastructure.Clock;
using ModuleMonolith.Common.Infrastructure.Data;
using ModuleMonolith.Common.Infrastructure.Interceptors;
using Npgsql;
using StackExchange.Redis;

namespace ModuleMonolith.Common.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        Action<IRegistrationConfigurator>[] moduleConfigureConsumers,
        string databaseConnectionString,
        string redisConnectionString)
    {
        var npgsqlDataSource = new NpgsqlDataSourceBuilder(databaseConnectionString).Build();
        services.TryAddSingleton(npgsqlDataSource);

        services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

        services.AddSingleton<PublishDomainEventsInterceptor>();

        services.TryAddSingleton<IDateTimeProvider, DateTimeProvider>();

        try
        {
            var connectionMultiplexer = ConnectionMultiplexer.Connect(redisConnectionString) as IConnectionMultiplexer;
            services.TryAddSingleton(connectionMultiplexer);

            services.AddStackExchangeRedisCache(options =>
                options.ConnectionMultiplexerFactory = () => Task.FromResult(connectionMultiplexer));
        }
        catch
        {
            services.AddDistributedMemoryCache();
        }

        services.TryAddSingleton<ICacheService, CacheService>();

        services.TryAddSingleton<IEventBus, EventBus.EventBus>();

        services.AddMassTransit(configure =>
        {
            ////configure.AddConsumer<>();
            foreach (var configureConsumer in moduleConfigureConsumers)
            {
                configureConsumer(configure);
            }

            configure.SetKebabCaseEndpointNameFormatter();

            configure.UsingInMemory((context, cfg) =>
            {
                cfg.ConfigureEndpoints(context);
            });
        });


        return services;
    }
}

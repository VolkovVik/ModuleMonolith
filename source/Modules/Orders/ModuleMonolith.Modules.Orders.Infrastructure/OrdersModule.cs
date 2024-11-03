using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModuleMonolith.Common.Presentation.Endpoins;
using ModuleMonolith.Modules.Orders.Application.Carts;
using ModuleMonolith.Modules.Orders.Presentation.Customers;

namespace ModuleMonolith.Modules.Orders.Infrastructure;

public static class OrdersModule
{
    public static IServiceCollection AddOrdersModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddEndpoints(Presentation.AssemblyReference.Assembly);
        services.AddInfrastructure(configuration);
        return services;
    }

    public static void ConfigureConsumers(IRegistrationConfigurator registrationConfigurator)
    {
        registrationConfigurator.AddConsumer<UserRegisteredIntegrationEventConsumer>();
    }

    private static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        /// var databaseConnectionString = configuration.GetConnectionString("Database")!;
        // Will inplement later

        services.AddSingleton<CartService>();

        return services;
    }
}

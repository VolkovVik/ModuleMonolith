using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModuleMonolith.Common.Application.Data;
using ModuleMonolith.Common.Presentation.Endpoins;
using ModuleMonolith.Modules.Codes.Domain.Codes;
using ModuleMonolith.Modules.Codes.Infrastructure.Codes;
using ModuleMonolith.Modules.Codes.Infrastructure.Database;

namespace ModuleMonolith.Modules.Codes.Infrastructure;

public static class CodesModule
{
    public static IServiceCollection AddCodesModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddEndpoints(Presentation.AssemblyReference.Assembly);
        services.AddInfrastructure(configuration);
        return services;
    }

    private static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var databaseConnectionString = configuration.GetConnectionString("Database")!;

        services.AddDbContext<CodesDbContext>(options =>
            options
                .UseNpgsql(
                    databaseConnectionString,
                    npgsqlOptions => npgsqlOptions
                        .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Codes))
                .UseSnakeCaseNamingConvention());

        services.AddScoped<ICodesRepository, CodesRepository>();
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<CodesDbContext>());
        return services;
    }
}

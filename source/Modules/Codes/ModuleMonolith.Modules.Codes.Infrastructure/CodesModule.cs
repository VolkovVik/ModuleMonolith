﻿using FluentValidation;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModuleMonolith.Modules.Codes.Application;
using ModuleMonolith.Modules.Codes.Domain.Codes;
using ModuleMonolith.Modules.Codes.Infrastructure.Codes;
using ModuleMonolith.Modules.Codes.Infrastructure.Database;
using ModuleMonolith.Modules.Codes.Presentation;
using ModuleMonolith.Common.Application.Data;

namespace ModuleMonolith.Modules.Codes.Infrastructure;

public static class CodesModule
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        CodesEndpoints.MapEndpoints(app);
    }

    public static IServiceCollection AddCodesModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(AssemblyReference.Assembly);
        });
        services.AddValidatorsFromAssembly(AssemblyReference.Assembly, includeInternalTypes: true);
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

using Microsoft.EntityFrameworkCore;
using ModuleMonolith.Modules.Codes.Infrastructure.Database;
using ModuleMonolith.Modules.Users.Infrastructure.Database;

namespace ModuleMonolith.Api.Extensions;

internal static class MigrationExtensions
{
    internal static void ApplyMigrations(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        ApplyMigration<CodesDbContext>(scope);
        ApplyMigration<UsersDbContext>(scope);
    }

    private static void ApplyMigration<TDbContext>(IServiceScope scope)
        where TDbContext : DbContext
    {
        using var context = scope.ServiceProvider.GetRequiredService<TDbContext>();

        context.Database.Migrate();
    }
}

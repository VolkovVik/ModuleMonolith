using Microsoft.EntityFrameworkCore;

namespace ModuleMonolith.Modules.Codes.Api.Database;

public sealed class CodesDbContext(DbContextOptions<CodesDbContext> options) : DbContext(options)
{
    internal DbSet<Code> Codes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Codes);

        modelBuilder.Entity<Code>().ToTable("codes");
    }
}

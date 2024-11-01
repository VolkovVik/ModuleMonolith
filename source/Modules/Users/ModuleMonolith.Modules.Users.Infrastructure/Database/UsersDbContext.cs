using Microsoft.EntityFrameworkCore;
using ModuleMonolith.Modules.Users.Application.Abstractions.Data;
using ModuleMonolith.Modules.Users.Domain.Users;
using ModuleMonolith.Modules.Users.Infrastructure.Users;

namespace ModuleMonolith.Modules.Users.Infrastructure.Database;

public sealed class UsersDbContext(DbContextOptions<UsersDbContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Users);

        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}

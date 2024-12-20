﻿using Microsoft.EntityFrameworkCore;
using ModuleMonolith.Modules.Codes.Domain.Codes;
using ModuleMonolith.Common.Application.Data;

namespace ModuleMonolith.Modules.Codes.Infrastructure.Database;

public sealed class CodesDbContext(DbContextOptions<CodesDbContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<Code> Codes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Codes);

        modelBuilder.Entity<Code>().ToTable("codes");
    }
}

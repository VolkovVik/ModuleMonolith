using System.Data.Common;
using ModuleMonolith.Modules.Codes.Application.Abstractions.Data;
using Npgsql;

namespace ModuleMonolith.Common.Infrastructure.Data;

internal sealed class DbConnectionFactory(NpgsqlDataSource dataSource) : IDbConnectionFactory
{
    public async ValueTask<DbConnection> OpenConnectionAsync(CancellationToken cancellationToken = default)
    {
        return await dataSource.OpenConnectionAsync(cancellationToken);
    }
}

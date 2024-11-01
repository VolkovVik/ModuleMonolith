using Dapper;
using ModuleMonolith.Common.Application.Data;
using ModuleMonolith.Common.Application.Messaging;
using ModuleMonolith.Common.Domain;
using ModuleMonolith.Modules.Users.Application.Users.GetUser;

namespace ModuleMonolith.Modules.Users.Application.Users.GetUsers;

internal sealed class GetUsersQueryHandler(IDbConnectionFactory dbConnectionFactory)
    : IQueryHandler<GetUsersQuery, IReadOnlyCollection<UserResponse>>
{
    public async Task<Result<IReadOnlyCollection<UserResponse>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        await using var connection = await dbConnectionFactory.OpenConnectionAsync(cancellationToken);

        const string sql =
            $"""
             SELECT
                 id AS {nameof(UserResponse.Id)},
                 email AS {nameof(UserResponse.Email)},
                 first_name AS {nameof(UserResponse.FirstName)},
                 last_name AS {nameof(UserResponse.LastName)}
             FROM users.users
             """;

        var items = (await connection.QueryAsync<UserResponse>(sql, request)).AsList();
        return items;
    }
}

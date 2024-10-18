using Dapper;
using ModuleMonolith.Modules.Codes.Application.Abstractions.Data;
using ModuleMonolith.Modules.Codes.Application.Abstractions.Messaging;
using ModuleMonolith.Modules.Codes.Application.Codes.CreateCode;
using ModuleMonolith.Modules.Codes.Domain.Abstractions;

namespace ModuleMonolith.Modules.Codes.Application.Codes.GetCodes;

internal sealed class GetCodesQueryHandler(IDbConnectionFactory dbConnectionFactory) : IQueryHandler<GetCodesQuery, IReadOnlyCollection<CodeResponse>>
{
    public async Task<Result<IReadOnlyCollection<CodeResponse>>> Handle(GetCodesQuery request, CancellationToken cancellationToken)
    {
        await using var connection = await dbConnectionFactory.OpenConnectionAsync(cancellationToken);
        const string sql =
            $"""
             SELECT
                 e.id AS {nameof(CodeResponse.Id)},
                 e.value AS {nameof(CodeResponse.Value)},
                 e.is_validated AS {nameof(CodeResponse.IsValidated)},
                 e.is_defeted AS {nameof(CodeResponse.IsDefeted)}
             FROM codes.codes e
             """;
        var items = (await connection.QueryAsync<CodeResponse>(sql, request)).AsList();
        return items;
    }
}

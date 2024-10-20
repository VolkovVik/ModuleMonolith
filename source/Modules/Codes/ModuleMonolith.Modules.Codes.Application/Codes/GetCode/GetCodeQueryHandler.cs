using Dapper;
using ModuleMonolith.Common.Application.Messaging;
using ModuleMonolith.Common.Domain;
using ModuleMonolith.Modules.Codes.Application.Abstractions.Data;
using ModuleMonolith.Modules.Codes.Application.Codes.CreateCode;

namespace ModuleMonolith.Modules.Codes.Application.Codes.GetCode;

internal sealed class GetCodeQueryHandler(IDbConnectionFactory dbConnectionFactory) : IQueryHandler<GetCodeQuery, CodeResponse?>
{
    public async Task<Result<CodeResponse?>> Handle(GetCodeQuery request, CancellationToken cancellationToken)
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
             WHERE e.id = @CodeId
             """;
        var value = await connection.QuerySingleOrDefaultAsync<CodeResponse>(sql, new { request.CodeId });
        return value;
    }
}

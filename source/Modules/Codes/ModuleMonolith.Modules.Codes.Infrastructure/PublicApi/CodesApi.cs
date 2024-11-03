using MediatR;
using ModuleMonolith.Modules.Codes.Application.Codes.GetCode;
using ModuleMonolith.Modules.Codes.PublicApi;

namespace ModuleMonolith.Modules.Codes.Infrastructure.PublicApi;

internal sealed class CodesApi(ISender sender) : ICodesApi
{
    public async Task<CodeResponse?> GetAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var result = await sender.Send(new GetCodeQuery(userId), cancellationToken);

        if (result.IsFailure)
            return null;

        return new CodeResponse(
            result.Value.Id,
            result.Value.Value,
            result.Value.IsValidated,
            result.Value.IsDefeted);
    }
}

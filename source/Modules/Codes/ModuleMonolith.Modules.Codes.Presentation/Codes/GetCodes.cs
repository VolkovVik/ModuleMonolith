using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ModuleMonolith.Common.Application.Caching;
using ModuleMonolith.Modules.Codes.Application.Codes.CreateCode;
using ModuleMonolith.Modules.Codes.Application.Codes.GetCodes;
using ModuleMonolith.Modules.Codes.Presentation.ApiResults;

namespace ModuleMonolith.Modules.Codes.Presentation.Codes;

internal static class GetCodes
{
    internal static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("codes", async (ISender sender, ICacheService cacheService, CancellationToken cancellationToken) =>
        {
            var codes = await cacheService.GetAsync<IReadOnlyCollection<CodeResponse>>("codes", cancellationToken);
            if (codes is not null)
                return Results.Ok(codes);

            var query = new GetCodesQuery();
            var result = await sender.Send(query, cancellationToken);
            if (result.IsSuccess)
                await cacheService.SetAsync("codes", result.Value, null, cancellationToken);

            return result.Match(Results.Ok, ApiResults.ApiResults.Problem);
        })
        .WithTags(Tags.Codes);
    }
}

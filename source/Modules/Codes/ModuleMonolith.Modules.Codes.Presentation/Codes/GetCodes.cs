using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ModuleMonolith.Common.Application.Caching;
using ModuleMonolith.Common.Presentation.ApiResults;
using ModuleMonolith.Modules.Codes.Application.Codes.CreateCode;
using ModuleMonolith.Modules.Codes.Application.Codes.GetCodes;

namespace ModuleMonolith.Modules.Codes.Presentation.Codes;

public sealed class GetCodes : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
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

            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Codes);
    }
}

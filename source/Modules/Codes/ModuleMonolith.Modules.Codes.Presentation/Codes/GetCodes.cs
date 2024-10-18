using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ModuleMonolith.Modules.Codes.Application.Codes.GetCodes;
using ModuleMonolith.Modules.Codes.Presentation.ApiResults;

namespace ModuleMonolith.Modules.Codes.Presentation.Codes;

internal static class GetCodes
{
    internal static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("codes", async (ISender sender, CancellationToken cancellationToken) =>
        {
            var query = new GetCodesQuery();
            var result = await sender.Send(query, cancellationToken);
            return result.Match(Results.Ok, ApiResults.ApiResults.Problem);
        })
        .WithTags(Tags.Codes);
    }
}

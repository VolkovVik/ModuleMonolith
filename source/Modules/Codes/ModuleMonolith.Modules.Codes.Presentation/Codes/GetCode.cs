using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ModuleMonolith.Modules.Codes.Application.Codes.GetCode;

namespace ModuleMonolith.Modules.Codes.Presentation.Codes;

internal static class GetCode
{
    internal static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("codes/{id}", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
        {
            var query = new GetCodeQuery(id);
            var value = await sender.Send(query, cancellationToken);
            return value == null ? Results.NotFound() : Results.Ok(value);
        })
        .WithTags(Tags.Codes);
    }
}

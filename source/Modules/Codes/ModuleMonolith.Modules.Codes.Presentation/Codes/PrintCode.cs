using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ModuleMonolith.Modules.Codes.Application.Codes.PrintCode;

namespace ModuleMonolith.Modules.Codes.Presentation.Codes;

internal static class PrintCode
{
    internal static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("codes/print", async (Request request, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new PrintCodeCommand(request.Id);
            var id = await sender.Send(command, cancellationToken);
            return Results.Ok(id);
        })
        .WithTags(Tags.Codes);
    }

    internal sealed class Request
    {
        public Guid Id { get; set; }
    }
}

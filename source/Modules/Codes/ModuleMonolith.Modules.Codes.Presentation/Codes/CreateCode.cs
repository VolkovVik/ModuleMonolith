using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ModuleMonolith.Modules.Codes.Application.Codes.CreateCode;
using ModuleMonolith.Modules.Codes.Presentation.ApiResults;

namespace ModuleMonolith.Modules.Codes.Presentation.Codes;

internal static class CreateCode
{
    internal static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("codes", async (Request request, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new CreateCodeCommand(
                request.Value,
                request.IsValidated,
                request.IsDefeted);
            var result = await sender.Send(command, cancellationToken);
            return result.Match(Results.Ok, ApiResults.ApiResults.Problem);
        })
        .WithTags(Tags.Codes);
    }

    internal sealed class Request
    {
        public string Value { get; set; }
        public bool IsValidated { get; set; }
        public bool IsDefeted { get; set; }
    }
}

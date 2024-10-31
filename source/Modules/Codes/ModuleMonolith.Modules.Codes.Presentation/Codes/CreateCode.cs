using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ModuleMonolith.Common.Presentation.ApiResults;
using ModuleMonolith.Modules.Codes.Application.Codes.CreateCode;

namespace ModuleMonolith.Modules.Codes.Presentation.Codes;

public sealed class CreateCode : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("codes", async (Request request, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new CreateCodeCommand(
                request.Value,
                request.IsValidated,
                request.IsDefeted);
            var result = await sender.Send(command, cancellationToken);
            return result.Match(Results.Ok, ApiResults.Problem);
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

using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ModuleMonolith.Modules.Codes.Application.Codes.DefectCode;
using ModuleMonolith.Modules.Codes.Presentation.ApiResults;

namespace ModuleMonolith.Modules.Codes.Presentation.Codes;

internal static class DefectCode
{
    internal static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("codes/defect", async (Request request, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new DefectCodeCommand(request.Id);
            var result = await sender.Send(command, cancellationToken);
            return result.Match(Results.NoContent, ApiResults.ApiResults.Problem);
        })
        .WithTags(Tags.Codes);
    }

    internal sealed class Request
    {
        public Guid Id { get; set; }
    }
}

using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ModuleMonolith.Common.Presentation.ApiResults;
using ModuleMonolith.Modules.Codes.Application.Codes.DefectCode;

namespace ModuleMonolith.Modules.Codes.Presentation.Codes;

public sealed class DefectCode : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("codes/defect", async (Request request, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = new DefectCodeCommand(request.Id);
            var result = await sender.Send(command, cancellationToken);
            return result.Match(Results.NoContent, ApiResults.Problem);
        })
        .WithTags(Tags.Codes);
    }

    internal sealed class Request
    {
        public Guid Id { get; set; }
    }
}

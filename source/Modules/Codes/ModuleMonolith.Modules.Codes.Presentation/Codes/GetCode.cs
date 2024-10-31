using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ModuleMonolith.Common.Presentation.ApiResults;
using ModuleMonolith.Modules.Codes.Application.Codes.GetCode;

namespace ModuleMonolith.Modules.Codes.Presentation.Codes;

public sealed class GetCode : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("codes/{id}", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
        {
            var query = new GetCodeQuery(id);
            var result = await sender.Send(query, cancellationToken);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Codes);
    }
}

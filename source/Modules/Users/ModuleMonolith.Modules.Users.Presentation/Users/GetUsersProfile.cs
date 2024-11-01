using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ModuleMonolith.Common.Presentation.ApiResults;
using ModuleMonolith.Modules.Users.Application.Users.GetUsers;

namespace ModuleMonolith.Modules.Users.Presentation.Users;

public sealed class GetUsersProfile : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("users/profile", async (ISender sender, CancellationToken cancellationToken) =>
        {
            var result = await sender.Send(new GetUsersQuery(), cancellationToken);

            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Users);
    }
}

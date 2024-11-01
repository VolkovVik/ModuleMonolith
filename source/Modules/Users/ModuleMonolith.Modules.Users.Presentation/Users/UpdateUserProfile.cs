using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ModuleMonolith.Common.Presentation.ApiResults;
using ModuleMonolith.Modules.Users.Application.Users.UpdateUser;

namespace ModuleMonolith.Modules.Users.Presentation.Users;

public sealed class UpdateUserProfile : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("users/{id}/profile", async (Guid id, Request request, ISender sender) =>
        {
            var result = await sender.Send(new UpdateUserCommand(
                id,
                request.FirstName,
                request.LastName));

            return result.Match(Results.NoContent, ApiResults.Problem);
        })
        .WithTags(Tags.Users);
    }

    internal sealed class Request
    {
        public string FirstName { get; init; }

        public string LastName { get; init; }
    }
}

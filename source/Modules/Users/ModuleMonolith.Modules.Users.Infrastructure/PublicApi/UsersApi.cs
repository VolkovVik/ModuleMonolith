using MediatR;
using ModuleMonolith.Modules.Users.Application.Users.GetUser;
using ModuleMonolith.Modules.Users.PublicApi;

namespace ModuleMonolith.Modules.Users.Infrastructure.PublicApi;

internal sealed class UsersApi(ISender sender) : IUsersApi
{
    public async Task<Modules.Users.PublicApi.UserResponse?> GetAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var result = await sender.Send(new GetUserQuery(userId), cancellationToken);

        if (result.IsFailure)
            return null;

        return new Modules.Users.PublicApi.UserResponse(
            result.Value.Id,
            result.Value.Email,
            result.Value.FirstName,
            result.Value.LastName);
    }
}

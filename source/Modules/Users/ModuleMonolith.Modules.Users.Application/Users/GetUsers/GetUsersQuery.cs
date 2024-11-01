using ModuleMonolith.Common.Application.Messaging;
using ModuleMonolith.Modules.Users.Application.Users.GetUser;

namespace ModuleMonolith.Modules.Users.Application.Users.GetUsers;

public sealed record GetUsersQuery() : IQuery<IReadOnlyCollection<UserResponse>>;

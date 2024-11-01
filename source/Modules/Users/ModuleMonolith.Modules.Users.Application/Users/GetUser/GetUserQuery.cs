using ModuleMonolith.Common.Application.Messaging;

namespace ModuleMonolith.Modules.Users.Application.Users.GetUser;

public sealed record GetUserQuery(Guid UserId) : IQuery<UserResponse>;

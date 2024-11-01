﻿using ModuleMonolith.Common.Application.Messaging;

namespace ModuleMonolith.Modules.Users.Application.Users.UpdateUser;

public sealed record UpdateUserCommand(Guid UserId, string FirstName, string LastName) : ICommand;

﻿using ModuleMonolith.Common.Application.Messaging;

namespace ModuleMonolith.Modules.Users.Application.Users.RegisterUser;

public sealed record RegisterUserCommand(string Email, string Password, string FirstName, string LastName)
    : ICommand<Guid>;
using ModuleMonolith.Common.Application.Messaging;

namespace ModuleMonolith.Modules.Codes.Application.Codes.CreateCode;

public sealed record CreateCodeCommand(string Value, bool IsValidated, bool IsDefeted) : ICommand<Guid>;

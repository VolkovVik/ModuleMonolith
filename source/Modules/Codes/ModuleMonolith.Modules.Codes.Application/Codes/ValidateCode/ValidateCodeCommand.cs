using ModuleMonolith.Common.Application.Messaging;

namespace ModuleMonolith.Modules.Codes.Application.Codes.ValidateCode;

public sealed record ValidateCodeCommand(Guid CodeId) : ICommand;

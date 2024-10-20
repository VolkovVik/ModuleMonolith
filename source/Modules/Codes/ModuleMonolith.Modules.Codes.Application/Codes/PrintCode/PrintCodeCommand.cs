using ModuleMonolith.Common.Application.Messaging;

namespace ModuleMonolith.Modules.Codes.Application.Codes.PrintCode;

public sealed record PrintCodeCommand(Guid CodeId) : ICommand;

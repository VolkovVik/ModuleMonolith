using ModuleMonolith.Common.Application.Messaging;

namespace ModuleMonolith.Modules.Codes.Application.Codes.DefectCode;

public sealed record DefectCodeCommand(Guid CodeId) : ICommand;

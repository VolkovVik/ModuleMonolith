using MediatR;

namespace ModuleMonolith.Modules.Codes.Application.Codes.CreateCode;

public sealed record CreateCodeCommand(string Value, bool IsValidated, bool IsDefeted) : IRequest<Guid>;

using MediatR;
using ModuleMonolith.Modules.Codes.Application.Codes.CreateCode;

namespace ModuleMonolith.Modules.Codes.Application.Codes.GetCode;

public sealed record GetCodeQuery(Guid CodeId) : IRequest<CodeResponse?>;

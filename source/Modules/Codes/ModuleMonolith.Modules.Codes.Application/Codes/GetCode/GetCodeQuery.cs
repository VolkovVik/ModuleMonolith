using ModuleMonolith.Modules.Codes.Application.Codes.CreateCode;
using ModuleMonolith.Common.Application.Messaging;

namespace ModuleMonolith.Modules.Codes.Application.Codes.GetCode;

public sealed record GetCodeQuery(Guid CodeId) : IQuery<CodeResponse?>;

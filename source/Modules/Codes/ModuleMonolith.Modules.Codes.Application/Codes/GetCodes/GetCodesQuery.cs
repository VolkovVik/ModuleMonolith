using ModuleMonolith.Modules.Codes.Application.Abstractions.Messaging;
using ModuleMonolith.Modules.Codes.Application.Codes.CreateCode;

namespace ModuleMonolith.Modules.Codes.Application.Codes.GetCode;

public sealed record GetCodesQuery() : IQuery<IReadOnlyCollection<CodeResponse>>;

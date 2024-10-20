using ModuleMonolith.Modules.Codes.Application.Codes.CreateCode;
using ModuleMonolith.Common.Application.Messaging;

namespace ModuleMonolith.Modules.Codes.Application.Codes.GetCodes;

public sealed record GetCodesQuery() : IQuery<IReadOnlyCollection<CodeResponse>>;

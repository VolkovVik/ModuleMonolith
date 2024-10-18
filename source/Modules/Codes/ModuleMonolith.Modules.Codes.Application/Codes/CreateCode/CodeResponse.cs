namespace ModuleMonolith.Modules.Codes.Application.Codes.CreateCode;

public sealed record CodeResponse(Guid Id, string Value, bool IsValidated, bool IsDefeted);

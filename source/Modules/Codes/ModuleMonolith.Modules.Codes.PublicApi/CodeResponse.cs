namespace ModuleMonolith.Modules.Codes.PublicApi;

public sealed record CodeResponse(Guid Id, string Value, bool IsValidated, bool IsDefeted);

namespace ModuleMonolith.Modules.Codes.PublicApi;

public interface ICodesApi
{
    Task<CodeResponse?> GetAsync(Guid userId, CancellationToken cancellationToken = default);
}

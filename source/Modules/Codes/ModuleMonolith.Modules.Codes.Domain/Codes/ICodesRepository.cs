namespace ModuleMonolith.Modules.Codes.Domain.Codes;

public interface ICodesRepository
{
    Task Insert(Code code, CancellationToken cancellationToken = default);
}

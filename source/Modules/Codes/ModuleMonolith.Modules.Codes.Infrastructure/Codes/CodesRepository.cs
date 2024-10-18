using Microsoft.EntityFrameworkCore;
using ModuleMonolith.Modules.Codes.Domain.Codes;
using ModuleMonolith.Modules.Codes.Infrastructure.Database;

namespace ModuleMonolith.Modules.Codes.Infrastructure.Codes;
internal sealed class CodesRepository(CodesDbContext dbContext) : ICodesRepository
{
    public async Task Insert(Code code, CancellationToken cancellationToken = default)
    {
        await dbContext.Codes.AddAsync(code, cancellationToken);
    }

    public async Task<Code?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Codes.SingleOrDefaultAsync(e => e.Id == id, cancellationToken);
    }
}

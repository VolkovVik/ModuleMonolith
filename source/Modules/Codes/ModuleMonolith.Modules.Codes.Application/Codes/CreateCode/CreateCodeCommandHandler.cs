using MediatR;
using ModuleMonolith.Modules.Codes.Application.Abstractions.Data;
using ModuleMonolith.Modules.Codes.Domain.Codes;

namespace ModuleMonolith.Modules.Codes.Application.Codes.CreateCode;

internal sealed class CreateCodeCommandHandler(ICodesRepository codesRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateCodeCommand, Guid>
{
    public async Task<Guid> Handle(CreateCodeCommand request, CancellationToken cancellationToken)
    {
        var code = Code.Create(request.Value, request.IsValidated, request.IsDefeted);
        await codesRepository.Insert(code, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return code.Id;
    }
}

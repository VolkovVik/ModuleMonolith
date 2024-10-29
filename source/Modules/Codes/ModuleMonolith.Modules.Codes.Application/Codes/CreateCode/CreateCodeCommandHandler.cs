using ModuleMonolith.Common.Application.Data;
using ModuleMonolith.Common.Application.Messaging;
using ModuleMonolith.Common.Domain;
using ModuleMonolith.Modules.Codes.Domain.Codes;

namespace ModuleMonolith.Modules.Codes.Application.Codes.CreateCode;

internal sealed class CreateCodeCommandHandler(ICodesRepository codesRepository, IUnitOfWork unitOfWork) : ICommandHandler<CreateCodeCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateCodeCommand request, CancellationToken cancellationToken)
    {
        var result = Code.Create(request.Value, request.IsValidated, request.IsDefeted);
        if (result.IsFailure)
            return Result.Failure<Guid>(result.Error);

        await codesRepository.Insert(result.Value, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return result.Value.Id;
    }
}

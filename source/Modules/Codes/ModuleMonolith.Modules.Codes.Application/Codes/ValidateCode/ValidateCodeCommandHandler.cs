using ModuleMonolith.Common.Application.Messaging;
using ModuleMonolith.Common.Domain;
using ModuleMonolith.Modules.Codes.Domain.Codes;
using ModuleMonolith.Common.Application.Data;

namespace ModuleMonolith.Modules.Codes.Application.Codes.ValidateCode;

internal sealed class ValidateCodeCommandHandler(ICodesRepository codesRepository, IUnitOfWork unitOfWork) : ICommandHandler<ValidateCodeCommand>
{
    public async Task<Result> Handle(ValidateCodeCommand request, CancellationToken cancellationToken)
    {
        var code = await codesRepository.GetAsync(request.CodeId, cancellationToken);
        if (code is null)
            return Result.Failure(CodeErrors.NotFound(request.CodeId));

        var result = code.Validated();
        if (result.IsFailure)
            return Result.Failure(result.Error);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}

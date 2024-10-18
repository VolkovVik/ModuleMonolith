using MediatR;
using ModuleMonolith.Modules.Codes.Application.Abstractions.Data;
using ModuleMonolith.Modules.Codes.Domain.Codes;

namespace ModuleMonolith.Modules.Codes.Application.Codes.CreateCode;

internal sealed class CreateCodeCommandHandler(ICodesRepository codesRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateCodeCommand, Guid>
{
    public async Task<Guid> Handle(CreateCodeCommand request, CancellationToken cancellationToken)
    {
        var code = new Code
        {
            Id = Guid.NewGuid(),
            Value = request.Value,
            IsValidated = request.IsValidated,
            IsDefeted = request.IsDefeted,
            PrintingStatus = CodePrintingStatus.Unprinted,
            AggregatingStatus = CodeAggregatingStatus.None
        };

        await codesRepository.Insert(code, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return code.Id;
    }
}

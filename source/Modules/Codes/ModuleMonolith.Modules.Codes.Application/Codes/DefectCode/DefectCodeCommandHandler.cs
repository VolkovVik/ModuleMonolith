﻿using ModuleMonolith.Modules.Codes.Application.Abstractions.Data;
using ModuleMonolith.Modules.Codes.Application.Abstractions.Messaging;
using ModuleMonolith.Modules.Codes.Domain.Abstractions;
using ModuleMonolith.Modules.Codes.Domain.Codes;

namespace ModuleMonolith.Modules.Codes.Application.Codes.DefectCode;

internal sealed class DefectCodeCommandHandler(ICodesRepository codesRepository, IUnitOfWork unitOfWork) : ICommandHandler<DefectCodeCommand>
{
    public async Task<Result> Handle(DefectCodeCommand request, CancellationToken cancellationToken)
    {
        var code = await codesRepository.GetAsync(request.CodeId, cancellationToken);
        if (code is null)
            return Result.Failure(CodeErrors.NotFound(request.CodeId));

        var result = code.Defected();
        if (result.IsFailure)
            return Result.Failure(result.Error);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
using FluentValidation;

namespace ModuleMonolith.Modules.Codes.Application.Codes.DefectCode;

internal sealed class DefectCodeCommandValidator : AbstractValidator<DefectCodeCommand>
{
    public DefectCodeCommandValidator()
    {
        RuleFor(c => c.CodeId).NotEmpty();
    }
}

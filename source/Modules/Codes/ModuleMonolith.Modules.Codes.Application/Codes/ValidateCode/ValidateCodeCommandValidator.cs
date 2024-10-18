using FluentValidation;

namespace ModuleMonolith.Modules.Codes.Application.Codes.ValidateCode;

internal sealed class ValidateCodeCommandValidator : AbstractValidator<ValidateCodeCommand>
{
    public ValidateCodeCommandValidator()
    {
        RuleFor(c => c.CodeId).NotEmpty();
    }
}

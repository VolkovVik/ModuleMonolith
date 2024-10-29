using FluentValidation;

namespace ModuleMonolith.Modules.Codes.Application.Codes.CreateCode;

internal sealed class CreateCodeCommandValidator : AbstractValidator<CreateCodeCommand>
{
    public CreateCodeCommandValidator()
    {
        RuleFor(x => x.Value)
            .Must(x => !string.IsNullOrWhiteSpace(x))
            .WithMessage("Value cannot be null or empty.");
    }
}

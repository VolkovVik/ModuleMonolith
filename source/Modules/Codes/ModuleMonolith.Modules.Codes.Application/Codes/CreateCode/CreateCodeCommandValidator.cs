using FluentValidation;

namespace ModuleMonolith.Modules.Codes.Application.Codes.CreateCode;

internal sealed class CreateCodeCommandValidator : AbstractValidator<CreateCodeCommand>
{
    public CreateCodeCommandValidator()
    {
        RuleFor(x => x.Value).NotEmpty();
    }
}

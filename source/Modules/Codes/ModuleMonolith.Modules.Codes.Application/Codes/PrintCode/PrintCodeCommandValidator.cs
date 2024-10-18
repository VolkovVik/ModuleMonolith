using FluentValidation;

namespace ModuleMonolith.Modules.Codes.Application.Codes.PrintCode;

internal sealed class PrintCodeCommandValidator : AbstractValidator<PrintCodeCommand>
{
    public PrintCodeCommandValidator()
    {
        RuleFor(c => c.CodeId).NotEmpty();
    }
}

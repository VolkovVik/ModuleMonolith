using ModuleMonolith.Modules.Codes.Domain.Abstractions;
using ModuleMonolith.Modules.Codes.Domain.Codes.DomainEvents;

namespace ModuleMonolith.Modules.Codes.Domain.Codes;

public sealed class Code : Entity
{
    private Code()
    {

    }

    public Guid Id { get; private set; }
    public string Value { get; private set; }

    public bool IsValidated { get; private set; }
    public bool IsDefeted { get; private set; }

    public CodePrintingStatus PrintingStatus { get; private set; }
    public CodeAggregatingStatus AggregatingStatus { get; private set; }

    public DateTime? PrintedAtUtc { get; private set; }
    public DateTime? ValidatedAtUtc { get; private set; }
    public DateTime? DefectedAtUtc { get; private set; }
    public DateTime? AggregatedAtUtc { get; private set; }

    public static Result<Code> Create(string value, bool isValidated, bool isDefeted)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result.Failure<Code>(CodeErrors.NullOrEmptyValue);

        var code = new Code()
        {
            Id = Guid.NewGuid(),
            Value = value,
            IsValidated = isValidated,
            IsDefeted = isDefeted,
            PrintingStatus = CodePrintingStatus.Unprinted,
            AggregatingStatus = CodeAggregatingStatus.None
        };

        code.Raise(new CodeCreatedDomainEvent(code.Id));

        return code;
    }

    public Result Printed()
    {
        PrintedAtUtc = DateTime.UtcNow;
        PrintingStatus = CodePrintingStatus.Printed;

        Raise(new CodePrintedDomainEvent(Id));

        return Result.Success();
    }

    public Result Validated()
    {
        if (!IsValidated)
            return Result.Failure(CodeErrors.CodeIsValidated);

        ValidatedAtUtc = DateTime.UtcNow;
        IsValidated = true;

        Raise(new CodeValidatedDomainEvent(Id));

        return Result.Success();
    }

    public Result Defected()
    {
        if (!IsDefeted)
            return Result.Failure(CodeErrors.CodeIsDefected);

        DefectedAtUtc = DateTime.UtcNow;
        IsDefeted = true;

        Raise(new CodeDefectedDomainEvent(Id));

        return Result.Success();
    }
}

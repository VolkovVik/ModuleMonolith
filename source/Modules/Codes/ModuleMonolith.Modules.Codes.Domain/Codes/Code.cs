using ModuleMonolith.Modules.Codes.Domain.Abstractions;

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

    public static Code Create(string value, bool isValidated, bool isDefeted)
    {
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
}

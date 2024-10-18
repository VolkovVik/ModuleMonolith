namespace ModuleMonolith.Modules.Codes.Domain.Codes;

public sealed class Code
{
    public Guid Id { get; set; }
    public string Value { get; set; }

    public bool IsValidated { get; set; }
    public bool IsDefeted { get; set; }

    public CodePrintingStatus PrintingStatus { get; set; }
    public CodeAggregatingStatus AggregatingStatus { get; set; }

    public DateTime? PrintedAtUtc { get; set; }
    public DateTime? ValidatedAtUtc { get; set; }
    public DateTime? DefectedAtUtc { get; set; }
    public DateTime? AggregatedAtUtc { get; set; }

}

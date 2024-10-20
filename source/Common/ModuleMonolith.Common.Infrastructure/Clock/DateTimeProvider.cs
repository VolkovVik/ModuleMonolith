using ModuleMonolith.Common.Application.Clock;

namespace ModuleMonolith.Common.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}

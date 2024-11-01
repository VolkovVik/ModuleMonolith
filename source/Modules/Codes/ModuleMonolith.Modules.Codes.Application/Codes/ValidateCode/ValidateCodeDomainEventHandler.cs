using ModuleMonolith.Common.Application.Messaging;
using ModuleMonolith.Modules.Codes.Domain.Codes.DomainEvents;

namespace ModuleMonolith.Modules.Codes.Application.Codes.ValidateCode;

internal sealed class ValidateCodeDomainEventHandler : IDomainEventHandler<ValidateCodeDomainEvent>
{
    public Task Handle(ValidateCodeDomainEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}

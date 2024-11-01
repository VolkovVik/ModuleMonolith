using ModuleMonolith.Common.Application.Messaging;
using ModuleMonolith.Modules.Codes.Domain.Codes.DomainEvents;

namespace ModuleMonolith.Modules.Codes.Application.Codes.CreateCode;

internal sealed class CreateCodeDomainEventHandler : IDomainEventHandler<CreateCodeDomainEvent>
{
    public Task Handle(CreateCodeDomainEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}

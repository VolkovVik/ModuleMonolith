using MediatR;
using ModuleMonolith.Common.Domain;

namespace ModuleMonolith.Common.Application.Messaging;

public interface IDomainEventHandler<in TDomainEvent> : INotificationHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent;

using MediatR;
using ModuleMonolith.Common.Application.EventBus;
using ModuleMonolith.Common.Application.Exceptions;
using ModuleMonolith.Common.Application.Messaging;
using ModuleMonolith.Modules.Users.Application.Users.GetUser;
using ModuleMonolith.Modules.Users.Domain.Users;
using ModuleMonolith.Modules.Users.IntegrationEvents;

namespace ModuleMonolith.Modules.Users.Application.Users.RegisterUser;

internal sealed class UserRegisteredDomainEventHandler(ISender sender, IEventBus eventBus)
    : IDomainEventHandler<UserRegisteredDomainEvent>
{
    public async Task Handle(UserRegisteredDomainEvent notification, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetUserQuery(notification.UserId), cancellationToken);

        if (result.IsFailure)
            throw new ModuleMonolithException(nameof(GetUserQuery), result.Error);

        await eventBus.PublishAsync(
            new UserRegisteredIntegrationEvent(
                notification.Id,
                notification.OccurredOnUtc,
                result.Value.Id,
                result.Value.Email,
                result.Value.FirstName,
                result.Value.LastName),
            cancellationToken);
    }
}

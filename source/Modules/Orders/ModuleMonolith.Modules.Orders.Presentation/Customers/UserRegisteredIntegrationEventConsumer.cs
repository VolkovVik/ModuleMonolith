using MassTransit;
using MediatR;
using ModuleMonolith.Common.Application.Exceptions;
using ModuleMonolith.Modules.Orders.Application.Customers.CreateCustomer;
using ModuleMonolith.Modules.Users.IntegrationEvents;

namespace ModuleMonolith.Modules.Orders.Presentation.Customers;

public sealed class UserRegisteredIntegrationEventConsumer(ISender sender)
    : IConsumer<UserRegisteredIntegrationEvent>
{
    public async Task Consume(ConsumeContext<UserRegisteredIntegrationEvent> context)
    {
        var result = await sender.Send(
            new CreateCustomerCommand(
                context.Message.UserId,
                context.Message.Email,
                context.Message.FirstName,
                context.Message.LastName));

        if (result.IsFailure)
        {
            throw new ModuleMonolithException(nameof(CreateCustomerCommand), result.Error);
        }
    }
}

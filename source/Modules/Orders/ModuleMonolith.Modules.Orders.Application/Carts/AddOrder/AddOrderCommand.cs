using FluentValidation;
using ModuleMonolith.Common.Application.Messaging;
using ModuleMonolith.Common.Domain;
using ModuleMonolith.Modules.Codes.PublicApi;
using ModuleMonolith.Modules.Orders.Domain.Customers;
using ModuleMonolith.Modules.Orders.Domain.Events;
using ModuleMonolith.Modules.Users.PublicApi;

namespace ModuleMonolith.Modules.Orders.Application.Carts.AddOrder;

public sealed record AddOrderCommand(Guid CustomerId, Guid TicketTypeId, decimal Quantity) : ICommand;

internal sealed class AddOrderCommandValidator : AbstractValidator<AddOrderCommand>
{
    public AddOrderCommandValidator()
    {
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.TicketTypeId).NotEmpty();
        RuleFor(c => c.Quantity).GreaterThan(decimal.Zero);
    }
}

internal sealed class AddOrderCommandHandler(CartService cartService, IUsersApi usersApi, ICodesApi codesApi)
    : ICommandHandler<AddOrderCommand>
{
    public async Task<Result> Handle(AddOrderCommand request, CancellationToken cancellationToken)
    {
        // 1. Get customer
        var customer = await usersApi.GetAsync(request.CustomerId, cancellationToken);
        if (customer is null)
            return Result.Failure(CustomerErrors.NotFound(request.CustomerId));

        // 2. Get ticket type
        var code = await codesApi.GetAsync(request.TicketTypeId, cancellationToken);
        if (code is null)
            return Result.Failure(TicketTypeErrors.NotFound(request.TicketTypeId));

        // 3. Add item to cart
        var cartItem = new CartItem
        {
            CodeId = code.Id,
            Price = 10,
            Quantity = request.Quantity,
            Currency = "100",
        };

        await cartService.AddItemAsync(customer.Id, cartItem, cancellationToken);

        return Result.Success();
    }
}

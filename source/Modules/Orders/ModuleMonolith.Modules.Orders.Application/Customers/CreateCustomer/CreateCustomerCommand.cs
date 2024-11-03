using ModuleMonolith.Common.Application.Messaging;

namespace ModuleMonolith.Modules.Orders.Application.Customers.CreateCustomer;

public sealed record CreateCustomerCommand(Guid CustomerId, string Email, string FirstName, string LastName)
    : ICommand;

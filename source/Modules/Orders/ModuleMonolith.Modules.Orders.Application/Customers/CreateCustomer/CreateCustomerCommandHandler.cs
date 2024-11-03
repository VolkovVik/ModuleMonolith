using ModuleMonolith.Common.Application.Messaging;
using ModuleMonolith.Common.Domain;

namespace ModuleMonolith.Modules.Orders.Application.Customers.CreateCustomer;

internal sealed class CreateCustomerCommandHandler()
    : ICommandHandler<CreateCustomerCommand>
{
    public async Task<Result> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        await Task.Delay(1000, cancellationToken);
        return Result.Success();
    }
}

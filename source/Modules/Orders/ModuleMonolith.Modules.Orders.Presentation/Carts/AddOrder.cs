using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ModuleMonolith.Common.Presentation.ApiResults;
using ModuleMonolith.Modules.Orders.Application.Carts.AddOrder;

namespace ModuleMonolith.Modules.Orders.Presentation.Carts;

public sealed class AddOrder : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("order/add", async (Request request, ISender sender) =>
        {
            var result = await sender.Send(
                new AddOrderCommand(
                    request.CustomerId,
                    request.CodeId,
                    request.Quantity));

            return result.Match(() => Results.Ok(), ApiResults.Problem);
        })
        .WithTags(Tags.Orders);
    }

    internal sealed class Request
    {
        public Guid CustomerId { get; init; }

        public Guid CodeId { get; init; }

        public decimal Quantity { get; init; }
    }
}

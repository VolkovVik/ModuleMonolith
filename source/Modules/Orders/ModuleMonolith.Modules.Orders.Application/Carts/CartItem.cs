namespace ModuleMonolith.Modules.Orders.Application.Carts;

public sealed class CartItem
{
    public Guid CodeId { get; set; }

    public decimal Quantity { get; set; }

    public decimal Price { get; set; }

    public string Currency { get; set; }
}

using ModuleMonolith.Common.Application.Caching;

namespace ModuleMonolith.Modules.Orders.Application.Carts;

public sealed class CartService(ICacheService cacheService)
{
    private static readonly TimeSpan DefaultExpiration = TimeSpan.FromMinutes(20);

    public async Task<Cart> GetAsync(Guid customerId, CancellationToken cancellationToken = default)
    {
        var cacheKey = CreateCacheKey(customerId);

        var cart = await cacheService.GetAsync<Cart>(cacheKey, cancellationToken) ??
                    Cart.CreateDefault(customerId);

        return cart;
    }

    public async Task ClearAsync(Guid customerId, CancellationToken cancellationToken = default)
    {
        var cacheKey = CreateCacheKey(customerId);

        var cart = Cart.CreateDefault(customerId);

        await cacheService.SetAsync(cacheKey, cart, DefaultExpiration, cancellationToken);
    }

    public async Task AddItemAsync(Guid customerId, CartItem cartItem, CancellationToken cancellationToken = default)
    {
        var cacheKey = CreateCacheKey(customerId);

        var cart = await GetAsync(customerId, cancellationToken);

        var existingCartItem = cart.Items.Find(c => c.CodeId == cartItem.CodeId);

        if (existingCartItem is null)
        {
            cart.Items.Add(cartItem);
        }
        else
        {
            existingCartItem.Quantity += cartItem.Quantity;
        }

        await cacheService.SetAsync(cacheKey, cart, DefaultExpiration, cancellationToken);
    }

    public async Task RemoveItemAsync(Guid customerId, Guid codeId, CancellationToken cancellationToken = default)
    {
        var cacheKey = CreateCacheKey(customerId);

        var cart = await GetAsync(customerId, cancellationToken);

        var cartItem = cart.Items.Find(c => c.CodeId == codeId);

        if (cartItem is null)
        {
            return;
        }

        cart.Items.Remove(cartItem);

        await cacheService.SetAsync(cacheKey, cart, DefaultExpiration, cancellationToken);
    }

    private static string CreateCacheKey(Guid customerId) => $"orders:{customerId}";
}

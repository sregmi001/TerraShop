using TerraShop.Domain.ShoppingCart;

namespace TerraShop.ShoppingCart.Data;
public class ShoppingCartRepository : IShoppingCartRepository
{
    private static readonly IDictionary<Guid, Basket> _baskets = new Dictionary<Guid, Basket>();
    public Task<Basket?> GetAsync(BasketId id)
    {
        _baskets.TryGetValue(id.Value, out Basket? basket);
        return Task.FromResult(basket);      
    }

    public Task<ICollection<Basket>> GetAllAsync() => Task.FromResult(_baskets.Values);

    public Task<Basket?> GetByVisitorIdAsync(VisitorId visitorId)
    {
        var basket = _baskets.Values.FirstOrDefault(b => b.VisitorId.Value == visitorId.Value);
        return Task.FromResult(basket);
    }

    public Task RemoveAsync(Basket entity)
    {
        _baskets.Remove(entity.Id.Value);
        return Task.CompletedTask;
    }

    public Task SaveAsync(Basket entity)
    {
        _baskets[entity.Id.Value] = entity;
        return Task.CompletedTask;
    }
}
using TerraShop.Domain.Infrastructure;
using TerraShop.Domain.ShoppingCart;

public interface IShoppingCartRepository : IRepository<Basket, BasketId>
{
    public Task<Basket?> GetByVisitorIdAsync(VisitorId visitorId);
}
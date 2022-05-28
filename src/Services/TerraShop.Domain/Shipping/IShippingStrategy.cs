using TerraShop.Domain.Infrastructure;
using TerraShop.Domain.ShoppingCart;

namespace TerraShop.Domain.Shipping
{
    public interface IShippingStrategy
    {
        public Money Quote(Basket basket);
    }
}

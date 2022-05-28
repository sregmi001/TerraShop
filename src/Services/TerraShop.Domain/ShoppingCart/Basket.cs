using TerraShop.Domain.Infrastructure;
using TerraShop.Domain.Shared;

namespace TerraShop.Domain.ShoppingCart;

public class Basket
    : IEntity<BasketId>
{
    public BasketId Id { get; private set; }
    public VisitorId VisitorId { get; private set; }
    public IList<BasketItem> Items { get; private set; } = new List<BasketItem>();
    public Money TotalExShipping(IExchangeRatesProvider exchangeRateProvider) => new()
    {
        Value = Items.Select(i => i.Price.BaseCurrencyValue(exchangeRateProvider)).Sum(),
        Currency = Money.BaseCurrency
    };

    public static Basket Create(VisitorId visitorId)
    {
        return new Basket { Id = BasketId.NewId(), VisitorId = visitorId };
    }

    public void AddItem(ProductId productId, Money unitPrice, int quantity)
    {
        var existingItem = Items?.FirstOrDefault(i => i.ProductId.Value == productId.Value);

        if (existingItem != null)
        {
            existingItem.IncreaseQuantity(quantity);
        }
        else
        {
            (Items ?? new List<BasketItem>()).Add(BasketItem.Create(Id, productId, unitPrice, quantity));
        }
    }
    public void DeleteItem(ProductId productId)
    {
        var existingItem = Items?.FirstOrDefault(i => i.ProductId.Value == productId.Value);

        if (existingItem != null)
        {
            Items?.Remove(existingItem);
        }
    }

}

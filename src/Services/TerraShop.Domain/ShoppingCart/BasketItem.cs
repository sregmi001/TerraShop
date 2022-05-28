using TerraShop.Domain.Infrastructure;
using TerraShop.Domain.Shared;

namespace TerraShop.Domain.ShoppingCart
{
    public class BasketItem
    {
        public BasketItemId Id { get; private set; }
        public BasketId BasketId { get; private set; }
        public ProductId ProductId { get; private set; }
        public Money UnitPrice { get; private set; } = null!;
        public int Quantity { get; private set; }
        public Money Price => new() { Value = UnitPrice.Value * Quantity, Currency = UnitPrice.Currency };

        private BasketItem(BasketId basketId, ProductId productId, Money unitPrice, int quantity)
        {
            Id = BasketItemId.NewId();
            BasketId = basketId;
            ProductId = productId;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }
        private BasketItem() { } //required for ORM
        internal void IncreaseQuantity(int quantity)
        {
            EnsureNoNegativeQuantity(quantity);
            Quantity += quantity;
        }

        internal void DecreaseQuantity(int quantity)
        {
            EnsureNoNegativeQuantity(quantity);
            Quantity -= quantity;
        }

        public static BasketItem Create(BasketId basketId, ProductId productId, Money unitPrice, int quantity = 1)
        {
            EnsureNoNegativeQuantity(quantity);
            return new(basketId, productId, unitPrice, quantity);
        }

        private static void EnsureNoNegativeQuantity(int quantity)
        {
            if (quantity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity));
            }
        }
    }
}

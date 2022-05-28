namespace TerraShop.Domain.ShoppingCart
{
    public readonly struct BasketItemId
    {
        public Guid Value { get; }
        public BasketItemId (Guid value) => Value = value;
        public static BasketItemId NewId() => new(Guid.NewGuid());
    }
}

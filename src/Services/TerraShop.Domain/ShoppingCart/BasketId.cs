namespace TerraShop.Domain.ShoppingCart
{
    public readonly struct BasketId
    {
        public Guid Value { get; }
        public BasketId(Guid value) => Value = value;        
        public static BasketId NewId() => new(Guid.NewGuid());

    }
}

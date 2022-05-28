namespace TerraShop.Domain.ShoppingCart
{
    public readonly struct VisitorId
    {
        public Guid Value { get; }
        public VisitorId(Guid value) => Value = value;
        public static VisitorId NewId() => new(Guid.NewGuid());
    }
}

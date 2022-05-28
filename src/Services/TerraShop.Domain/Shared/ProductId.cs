using System.Diagnostics.CodeAnalysis;

namespace TerraShop.Domain.Shared
{
    public readonly struct ProductId
    {
        public Guid Value { get; }
        public ProductId(Guid value) => Value = value;
        public static ProductId NewId() => new(Guid.NewGuid());
    }
}

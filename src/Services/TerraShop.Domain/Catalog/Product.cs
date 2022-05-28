using TerraShop.Domain.Infrastructure;
using TerraShop.Domain.Shared;

namespace TerraShop.Domain.Catalog
{
    public class Product
        : IEntity<ProductId>
    {
        public ProductId Id { get; private set; }
        public string Name { get; private set; } = null!;
        public Money UnitPrice { get; private set; } = null!;
        private Product() { }
        public static Product Create(Guid id, string Name, Money price)
        {
            return new Product {  Id = new ProductId(id), Name = Name, UnitPrice = price };
        }
    }
}

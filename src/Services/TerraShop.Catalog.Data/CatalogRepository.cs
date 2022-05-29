using TerraShop.Domain.Catalog;
using TerraShop.Domain.Infrastructure;
using TerraShop.Domain.Shared;

namespace TerraShop.Catalog.Data
{
    public class CatalogRepository : ICatalogRepository
    {
        private static readonly ICollection<Product> _products = new List<Product>
        {
            Product.Create(new("f3dba809-4906-4692-a8d5-2995269ce441"), "Product A", new Money { Value = 10 }),
            Product.Create(new("b9ecb958-1f34-4517-a357-6443631c10ca"), "Product B", new Money { Value = 20 }),
            Product.Create(new("d22b2a6b-7a55-4069-b841-060946568824"), "Product C", new Money { Value = 30 })
        };
        public Task<Product?> GetAsync(ProductId id) => Task.FromResult(_products.SingleOrDefault(p => p.Id.Value == id.Value));

        public Task<ICollection<Product>> GetAllAsync() => Task.FromResult(_products);

        public Task RemoveAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
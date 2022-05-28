using TerraShop.Domain.Shared;

namespace TerraShop.Domain.Catalog
{
    public interface ICatalogRepository 
        : Infrastructure.IRepository<Product, ProductId>
    {
        
    }
}

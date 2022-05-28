using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TerraShop.ShoppingCart.Data
{
    public class DesignTImeShoppingCartDbContextFactory:IDesignTimeDbContextFactory<ShoppingCartDbContext>
    {
        public ShoppingCartDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ShoppingCartDbContext>();
            optionsBuilder.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString());

            return new ShoppingCartDbContext(optionsBuilder.Options);
        }
    }   
}

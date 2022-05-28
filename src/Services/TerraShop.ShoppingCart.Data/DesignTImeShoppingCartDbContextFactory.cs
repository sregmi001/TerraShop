using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TerraShop.ShoppingCart.Data
{
    public class DesignTImeShoppingCartDbContextFactory : IDesignTimeDbContextFactory<ShoppingCartDbContext>
    {
        public ShoppingCartDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
#if DEBUG
                .AddJsonFile("appsettings.Development.json", optional: true)
#endif
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
                .Build();
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<ShoppingCartDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new ShoppingCartDbContext(optionsBuilder.Options);
        }
    }
}

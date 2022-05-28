using MediatR;
using Microsoft.EntityFrameworkCore;
using TerraShop.Catalog.Data;
using TerraShop.Domain.Catalog;
using TerraShop.ShoppingCart.Data;

namespace TerraShop.Api.Configurator
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddTerraShopServices(this IServiceCollection services)
        {
            services.AddDbContext<ShoppingCartDbContext>(options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()));
            services.AddScoped<ICatalogRepository, CatalogRepository>();
            services.AddAutoMapper(typeof(Program));
            services.AddMediatR(typeof(Program));

            return services;
        }
    }
    
}

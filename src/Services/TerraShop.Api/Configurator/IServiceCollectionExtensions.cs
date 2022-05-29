using MediatR;
using TerraShop.Catalog.Data;
using TerraShop.Domain.Catalog;
using TerraShop.ShoppingCart.Data;

namespace TerraShop.Api.Configurator
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddTerraShopServices(this IServiceCollection services)
        {
            services.AddScoped<ICatalogRepository, CatalogRepository>();
            services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
            services.AddAutoMapper(typeof(Program));
            services.AddMediatR(typeof(Program));

            return services;
        }
    }

}

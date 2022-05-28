using AutoMapper;
using TerraShop.Api.Catalog.Query;
using TerraShop.Domain.Shared;
using TerraShop.Domain.ShoppingCart;

namespace TerraShop.Api.Catalog
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductId, Guid>().ConvertUsing(p => p.Value);
            CreateMap<VisitorId, Guid>().ConvertUsing(p => p.Value);
            CreateMap<BasketId, Guid>().ConvertUsing(p => p.Value);

            CreateMap<Domain.Infrastructure.Money, GetProducts.MoneyDto>();
            CreateMap<Domain.Catalog.Product, GetProducts.Response>();
        }
    }
}

using AutoMapper;
using TerraShop.Api.ShoppingCart.Query;
using TerraShop.Domain.Shared;
using TerraShop.Domain.ShoppingCart;

namespace TerraShop.Api.ShoppingCart
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductId, Guid>().ConvertUsing(p => p.Value);
            CreateMap<VisitorId, Guid>().ConvertUsing(p => p.Value);
            CreateMap<BasketId, Guid>().ConvertUsing(p => p.Value);

            CreateMap<Basket, GetBasket.Response>();
            CreateMap<BasketItem, GetBasket.Item>()
                .ForMember(m => m.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice.Value))
                .ForMember(m => m.Currency, opt => opt.MapFrom(src => src.UnitPrice.Currency));
        }
    }
}

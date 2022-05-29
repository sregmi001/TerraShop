using AutoMapper;
using MediatR;
using TerraShop.Domain.ShoppingCart;

namespace TerraShop.Api.ShoppingCart.Query
{
    public class GetBasket
    {
        public record Request: IRequest<Response?>
        {
            public Guid VisitorId { get; init; }
        }

        public record Item
        {
            public Guid ProductId { get; init; }
            public decimal Quantity { get; init; }
            public decimal UnitPrice { get; init; }
            public string Currency { get; init; } = null!;
        }

        public record Response
        {
            public Guid VisitorId { get; init; }
            public IList<Item> Items { get; init; } = new List<Item>();
        }

        public class Handler : IRequestHandler<Request, Response?>
        {
            private readonly IMapper _mapper;
            private readonly IShoppingCartRepository _shoppingCartRepository;


            public Handler(IMapper mapper, IShoppingCartRepository shoppingCartRepository)
            {
                _mapper = mapper;
                _shoppingCartRepository = shoppingCartRepository;
            }

            public async Task<Response?> Handle(Request request, CancellationToken cancellationToken)
            {
                var basket = await _shoppingCartRepository.GetByVisitorIdAsync(new VisitorId(request.VisitorId));
                return _mapper.Map<Response?>(basket);
            }   
        }
    }
}

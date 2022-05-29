using MediatR;
using TerraShop.Domain.Catalog;
using TerraShop.Domain.ShoppingCart;

namespace TerraShop.Api.ShoppingCart.Command
{
    public static class AddToBasket
    {
        public record Request : IRequest<Unit>
        {
            public Guid VisitorId { get; init; }

            public Guid ProductId { get; init; }

            public int Quantity { get; init; }
        }

        public class Handler : IRequestHandler<Request, Unit>
        {
            private readonly IShoppingCartRepository _shoppingCartRepository;
            private readonly ICatalogRepository _catalogRepository;

            public Handler(IShoppingCartRepository shoppingCartRepository, ICatalogRepository catalogRepository)
            {
                _shoppingCartRepository = shoppingCartRepository;
                _catalogRepository = catalogRepository;
            }

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var basket = await _shoppingCartRepository.GetByVisitorIdAsync(new VisitorId(request.VisitorId));
                var product = await _catalogRepository.GetAsync(new Domain.Shared.ProductId(request.ProductId));
                
                if(basket == null)
                {
                    basket = Basket.Create(new VisitorId(request.VisitorId));
                }

                basket.AddItem(new Domain.Shared.ProductId(request.ProductId), product!.UnitPrice, request.Quantity);

                await _shoppingCartRepository.SaveAsync(basket);
                return Unit.Value;
            }
        }

    }
}

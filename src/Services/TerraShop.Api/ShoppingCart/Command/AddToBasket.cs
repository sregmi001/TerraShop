using MediatR;
using Microsoft.EntityFrameworkCore;
using TerraShop.Domain.Catalog;
using TerraShop.Domain.ShoppingCart;
using TerraShop.ShoppingCart.Data;

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
            private readonly ShoppingCartDbContext _context;
            private readonly ICatalogRepository _catalogRepository;

            public Handler(ShoppingCartDbContext context, ICatalogRepository catalogRepository)
            {
                _context = context;
                _catalogRepository = catalogRepository;
            }

            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var basket = await _context.Baskets.FirstOrDefaultAsync(b => b.VisitorId.Value == request.VisitorId);
                var product = await _catalogRepository.Get(new Domain.Shared.ProductId(request.ProductId));
                
                if(basket == null)
                {
                    basket = Basket.Create(new VisitorId(request.VisitorId));
                }

                basket.AddItem(new Domain.Shared.ProductId(request.ProductId), product.UnitPrice, request.Quantity);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }

    }
}

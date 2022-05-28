using AutoMapper;
using MediatR;

namespace TerraShop.Api.ShoppingCart.Query
{
    public class GetBasket
    {
        public record Request: IRequest<Response>
        {
            public Guid VisitorId { get; init; }
        }

        public record Item
        {
            public Guid ProductId { get; init; }
            public string Name { get; init; } = null!;
            public decimal Quantity { get; init; }
            public decimal UnitPrice { get; init; }
            public string Currency { get; init; } = null!;
        }

        public record Response
        {
            public Guid VisitorId { get; init; }
            public IList<Item> Items { get; init; } = new List<Item>();
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IMapper _mapper;

            public Handler(IMapper mapper)
            {
                _mapper = mapper;
            }

            public Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}

using AutoMapper;
using MediatR;
using TerraShop.Domain.Catalog;

namespace TerraShop.Api.Catalog.Query
{
    public static class GetProducts
    {
        public record Request: IRequest<IList<Response>>
        { }
        public record Response
        {
            public Guid Id { get; set; }
            public string? Name { get; set; }
            public MoneyDto? UnitPrice { get; set; }
        }
        public record MoneyDto
        {
            public decimal? Value { get; set; }
            public string? Currency { get; set; }
        }

        public class Handler : IRequestHandler<Request, IList<Response>>
        {
            private readonly ICatalogRepository _catalogRepository;

            private  readonly IMapper _mapper;
            public Handler(ICatalogRepository catalogRepository, IMapper mapper)
            {
                _catalogRepository = catalogRepository;
                _mapper = mapper;
            }

            public async Task<IList<Response>> Handle(Request request, CancellationToken cancellationToken)
            {
                var result = await _catalogRepository.GetAllAsync();
                return _mapper.Map<IList<Response>>(result);
            }
        }
    }
}

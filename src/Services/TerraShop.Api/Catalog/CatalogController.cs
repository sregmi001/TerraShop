using MediatR;
using Microsoft.AspNetCore.Mvc;
using TerraShop.Api.Catalog.Query;

namespace TerraShop.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : Controller
    {
        private readonly IMediator _mediator;

        public CatalogController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("Products")]
        public async Task<ActionResult<IList<GetProducts.Response>>> GetProducts() => Ok(await _mediator.Send(new GetProducts.Request()));
    }
}

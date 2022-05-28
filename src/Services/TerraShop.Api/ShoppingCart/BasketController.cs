using MediatR;
using Microsoft.AspNetCore.Mvc;
using TerraShop.Api.ShoppingCart.Command;
using TerraShop.Api.ShoppingCart.Query;

namespace TerraShop.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasketController : Controller
    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{visitorId}")]
        public async Task<ActionResult<GetBasket.Response>> GetBasket([FromRoute] Guid visitorId)
        {
            return Ok(await _mediator.Send(new GetBasket.Request { VisitorId = visitorId }));
        }

        [HttpPost("{visitorId}")]
        public async Task<ActionResult> AddToBasket([FromRoute] Guid visitorId, [FromBody] AddToBasket.Request request, CancellationToken cancellationToken)
        {
            if(visitorId != request.VisitorId)
            {
                return BadRequest();
            }
            return Ok(await _mediator.Send(request, cancellationToken));
        }
    }
}

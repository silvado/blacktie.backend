using Application.Commands.CreateProductPricing;
using Application.Commands.DeleteProductPricing;
using Application.Commands.UpdateProductPricing;
using Application.Contracts.Product;
using Application.Queries.GetProductPricingById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/product-pricing")]
    [ApiController]
    public class ProductPricingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductPricingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Obtem o Product Pricing pelo ID
        /// </summary>                           
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductPricingDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var query = new GetProductPricingByIdQuery(id);

            var response = await _mediator.Send(query);

            if (response is null)
                return NoContent();

            return Ok(response);
        }

        /// <summary>
        /// Cria um novo registro de ProductPricing
        /// </summary>    
        /// <param name="request"></param>                     
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateProductPricingCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
        /// <summary>
        /// Atualiza um registro de ProductPricing
        /// </summary>    
        /// <param name="request"></param>                     
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateProductPricingCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        /// <summary>
        /// Deleta um registro de ProductPricing pelo Id
        /// </summary>    
        /// <param name="id"></param>                     
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var query = new DeleteProductPricingCommand(id);

            var response = await _mediator.Send(query);

            return Ok(response);
        }
    }
}

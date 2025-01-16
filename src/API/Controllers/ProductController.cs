using Application.Commands.CreateProduct;
using Application.Commands.DeleteProduct;
using Application.Commands.UpdateProduct;
using Application.Contracts.Product;
using Application.Queries.GetProduct;
using Application.Queries.GetProductById;
using Domain.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Obtem o product pelo ID
        /// </summary>                           
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var query = new GetProductByIdQuery(id);

            var response = await _mediator.Send(query);

            if (response is null)
                return NoContent();

            return Ok(response);
        }

        /// <summary>
        /// Obtem a lista de products
        /// </summary>                           
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(PagedList<ProductDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync([FromQuery] GetProductParameters parameters)
        {
            var query = new GetProductQuery(parameters);

            var response = await _mediator.Send(query);

            if (response is null)
                return NoContent();

            return Ok(response);
        }

        /// <summary>
        /// Cria um novo registro de Product
        /// </summary>    
        /// <param name="request"></param>                     
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateProductCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
        /// <summary>
        /// Atualiza um registro de Product
        /// </summary>    
        /// <param name="request"></param>                     
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateProductCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        /// <summary>
        /// Deleta um registro de Product pelo Id
        /// </summary>    
        /// <param name="id"></param>                     
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var query = new DeleteProductCommand(id);

            var response = await _mediator.Send(query);

            return Ok(response);
        }

    }
}

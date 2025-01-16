using Application.Commands.CreateOrder;
using Application.Commands.DeleteOrder;
using Application.Commands.UpdateOrder;
using Application.Contracts.Order;
using Application.Queries.GetOrder;
using Application.Queries.GetOrderById;
using Domain.Helpers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Obtem o order pelo ID
        /// </summary>                           
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var query = new GetOrderByIdQuery(id);

            var response = await _mediator.Send(query);

            if (response is null)
                return NoContent();

            return Ok(response);
        }

        /// <summary>
        /// Obtem a lista de orders
        /// </summary>                           
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(PagedList<OrderDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync([FromQuery] GetOrderParameters parameters)
        {
            var query = new GetOrderQuery(parameters);

            var response = await _mediator.Send(query);

            if (response is null)
                return NoContent();

            return Ok(response);
        }

        /// <summary>
        /// Cria um novo registro de Order
        /// </summary>    
        /// <param name="request"></param>                     
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateOrderCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
        /// <summary>
        /// Atualiza um registro de Order
        /// </summary>    
        /// <param name="request"></param>                     
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateOrderCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        /// <summary>
        /// Deleta um registro de Order pelo Id
        /// </summary>    
        /// <param name="id"></param>                     
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var query = new DeleteOrderCommand(id);

            var response = await _mediator.Send(query);

            return Ok(response);
        }
    }
}

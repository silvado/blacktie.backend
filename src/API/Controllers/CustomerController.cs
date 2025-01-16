using Application.Commands.CreateCustomer;
using Application.Commands.DeleteCustomer;
using Application.Commands.UpdateCustomer;
using Application.Contracts.Customer;
using Application.Queries.GetCustomer;
using Application.Queries.GetCustomerById;
using Domain.Helpers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/customer")]
    [ApiController]    
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(PagedList<CustomerDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCustomers([FromQuery] GetCustomerParameters queryParameters)
        {
            var query = new GetCustomerQuery(queryParameters);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(CustomerDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var query = new GetCustomerByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPut]
        [Authorize]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCustomerCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByIdAsync(Guid id)
        {
            var command = new DeleteCustomerCommand(id);
            await _mediator.Send(command);
            return Ok(true);
        }

        [HttpPost()]        
        [ProducesResponseType(typeof(CustomerDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCustomerCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}

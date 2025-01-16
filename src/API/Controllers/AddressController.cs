using Application.Commands.CreateAddress;
using Application.Commands.DeleteAddress;
using Application.Commands.UpdateAddress;
using Application.Contracts.Address;
using Application.Queries.GetAddress;
using Application.Queries.GetAddressById;
using Domain.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PagedList<AddressDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAddresss([FromQuery] GetAddressParameters queryParameters)
        {
            var query = new GetAddressQuery(queryParameters);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AddressDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var query = new GetAddressByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateAddressCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            var command = new DeleteAddressCommand(id);
            await _mediator.Send(command);
            return Ok(true);
        }

        [HttpPost()]
        [ProducesResponseType(typeof(AddressDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateAddressCommand request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}

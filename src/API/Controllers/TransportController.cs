using Application.Commands.CreateTransport;
using Application.Commands.DeleteTransport;
using Application.Commands.UpdateTransport;
using Application.Contracts.Transport;
using Application.Queries.GetTransport;
using Application.Queries.GetTransportById;
using Domain.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/transport")]
    [ApiController]
    public class TransportController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransportController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Obtem o transport pelo ID
        /// </summary>                           
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TransportDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTransportByIdAsync(Guid id)
        {
            var query = new GetTransportByIdQuery(id);

            var response = await _mediator.Send(query);

            if (response is null)
                return NoContent();

            return Ok(response);
        }

        /// <summary>
        /// Obtem a lista de transports
        /// </summary>                           
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(PagedList<TransportDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTransportAsync([FromQuery] GetTransportParameters parameters)
        {
            var query = new GetTransportQuery(parameters);

            var response = await _mediator.Send(query);

            if (response is null)
                return NoContent();

            return Ok(response);
        }

        /// <summary>
        /// Cria um novo registro de Transport
        /// </summary>    
        /// <param name="request"></param>                     
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(TransportDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateTransportAsync([FromBody] CreateTransportCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
        /// <summary>
        /// Atualiza um registro de Transport
        /// </summary>    
        /// <param name="request"></param>                     
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateTransportAsync([FromBody] UpdateTransportCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        /// <summary>
        /// Deleta um registro de Transport pelo Id
        /// </summary>    
        /// <param name="id"></param>                     
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteTransportAsync(Guid id)
        {
            var query = new DeleteTransportCommand(id);

            var response = await _mediator.Send(query);

            return Ok(response);
        }

    }
}

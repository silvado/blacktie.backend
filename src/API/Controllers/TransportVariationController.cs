using Application.Commands.CreateTransportVariation;
using Application.Commands.DeleteTransportVariation;
using Application.Commands.UpdateTransportVariation;
using Application.Contracts.Transport;
using Application.Queries.GetTransportVariationById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/transport-variation")]
    [ApiController]
    public class TransportVariationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransportVariationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Obtem o transport pelo ID
        /// </summary>                           
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TransportVariationDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var query = new GetTransportVariationByIdQuery(id);

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
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateTransportVariationCommand request)
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
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateTransportVariationCommand request)
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
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var query = new DeleteTransportVariationCommand(id);

            var response = await _mediator.Send(query);

            return Ok(response);
        }
    }
}

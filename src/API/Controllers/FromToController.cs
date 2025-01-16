using Application.Commands.CreateFromTo;
using Application.Commands.DeleteFromTo;
using Application.Commands.UpdateFromTo;
using Application.Contracts.FromTo;
using Application.Queries.GetFromTo;
using Application.Queries.GetFromToById;
using Domain.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/from-to")]
    [ApiController]
    public class FromToController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FromToController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Obtem o fromto pelo ID
        /// </summary>                           
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FromToDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var query = new GetFromToByIdQuery(id);

            var response = await _mediator.Send(query);

            if (response is null)
                return NoContent();

            return Ok(response);
        }

        /// <summary>
        /// Obtem a lista de fromtos
        /// </summary>                           
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(PagedList<FromToDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync([FromQuery] GetFromToParameters parameters)
        {
            var query = new GetFromToQuery(parameters);

            var response = await _mediator.Send(query);

            if (response is null)
                return NoContent();

            return Ok(response);
        }

        /// <summary>
        /// Cria um novo registro de FromTo
        /// </summary>    
        /// <param name="request"></param>                     
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(FromToDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateFromToCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
        /// <summary>
        /// Atualiza um registro de FromTo
        /// </summary>    
        /// <param name="request"></param>                     
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateFromToCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        /// <summary>
        /// Deleta um registro de FromTo pelo Id
        /// </summary>    
        /// <param name="id"></param>                     
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var query = new DeleteFromToCommand(id);

            var response = await _mediator.Send(query);

            return Ok(response);
        }
    }
}

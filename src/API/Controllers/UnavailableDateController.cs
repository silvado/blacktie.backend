using Application.Commands.CreateUnavailableDate;
using Application.Commands.DeleteUnavailableDate;
using Application.Commands.UpdateUnavailableDate;
using Application.Contracts.UnavailableDate;
using Application.Queries.GetAllUnavailableDate;
using Application.Queries.GetUnavailableDate;
using Application.Queries.GetUnavailableDateByYear;
using Domain.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/unavailable-date")]
    [ApiController]
    public class UnavailableDateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UnavailableDateController(IMediator mediator)
        {
            _mediator = mediator;
        }


        /// <summary>
        /// Obtem a lista de unavailabledates
        /// </summary>                           
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(PagedList<UnavailableDateDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync([FromQuery] GetUnavailableDateParameters parameters)
        {
            var query = new GetUnavailableDateQuery(parameters);

            var response = await _mediator.Send(query);

            if (response is null)
                return NoContent();

            return Ok(response);
        }

        /// <summary>
        /// Obtem a lista de unavailabledates
        /// </summary>                           
        /// <returns></returns>
        [HttpGet("all")]
        [ProducesResponseType(typeof(PagedList<UnavailableDateDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetAllUnavailableDateParameters parameters)
        {
            var query = new GetAllUnavailableDateQuery(parameters);

            var response = await _mediator.Send(query);

            if (response is null)
                return NoContent();

            return Ok(response);
        }

        /// <summary>
        /// Cria um novo registro de UnavailableDate
        /// </summary>    
        /// <param name="request"></param>                     
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(UnavailableDateDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateUnavailableDateCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
        /// <summary>
        /// Atualiza um registro de UnavailableDate
        /// </summary>    
        /// <param name="request"></param>                     
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateUnavailableDateCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        /// <summary>
        /// Deleta um registro de UnavailableDate pelo Id
        /// </summary>    
        /// <param name="id"></param>                     
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var query = new DeleteUnavailableDateCommand(id);

            var response = await _mediator.Send(query);

            return Ok(response);
        }
    }
}

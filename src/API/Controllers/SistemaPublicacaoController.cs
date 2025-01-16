using Application.Contracts;
using Application.Queries.GetSistemaPublicacao;
using Application.Queries.GetSistemaPublicacaoById;
using Domain.Helpers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    [Route("api/sistema-publicacao")]
    [ApiController]
    [Authorize]
    public class SistemaPublicacaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SistemaPublicacaoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Obtem uma lista paginada com o histórico de publicações do sistema
        /// </summary>  
        /// <param name="parameters"></param> 
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(PagedList<SistemaPublicacaoDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSistemaPublicacaoAsync([FromQuery] GetSistemaPublicacaoParameters parameters)
        {
            var query = new GetSistemaPublicacaoQuery(parameters);

            var response = await _mediator.Send(query);

            if (response is null)
                return NoContent();

            return Ok(response);
        }
        /// <summary>
        /// Obtem o histórico de publicações do sistema pelo id
        /// </summary>  
        /// <param name="id"></param> 
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SistemaPublicacaoDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSistemaPublicacaoByIdAsync(int id)
        {
            var query = new GetSistemaPublicacaoByIdQuery(id);

            var response = await _mediator.Send(query);

            if (response is null)
                return NoContent();

            return Ok(response);
        }

    }
}

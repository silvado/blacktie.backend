using Application.Commands.CreateSistema;
using Application.Commands.DeleteSistema;
using Application.Commands.PublishSistema;
using Application.Commands.UpdateSistema;
using Application.Commands.UpdateSistemaCredencial;
using Application.Contracts;
using Application.Contracts.Sistema;
using Application.Queries.GetSistema;
using Application.Queries.GetSistemaById;
using Application.Queries.GetSistemaConfig;
using Domain.Helpers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    [Route("api/sistema")]
    [ApiController]
    [Authorize]
    public class SistemaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SistemaController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Obtem o sistema pelo ID
        /// </summary>                           
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SistemaDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSistemaByIdAsync(int id)
                    {
            var query = new GetSistemaByIdQuery(id);

            var response = await _mediator.Send(query);

            if (response is null)
                return NoContent();

            return Ok(response);
        }

        /// <summary>
        /// Obtem a lista de sistemas
        /// </summary>                           
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(PagedList<SistemaDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSistemaAsync([FromQuery] GetSistemaParameters parameters)
        {
            var query = new GetSistemaQuery(parameters);

            var response = await _mediator.Send(query);

            if (response is null)
                return NoContent();

            return Ok(response);
        }

        /// <summary>
        /// Cria um novo registro de Sistema
        /// </summary>    
        /// <param name="request"></param>                     
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(SistemaCadastroDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateSistemaAsync([FromBody] CreateSistemaCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
        /// <summary>
        /// Atualiza um registro de Sistema
        /// </summary>    
        /// <param name="request"></param>                     
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateSistemaAsync([FromBody] UpdateSistemaCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        /// <summary>
        /// Atualiza um registro de Sistema
        /// </summary>    
        /// <param name="request"></param>                     
        /// <returns></returns>
        [HttpPut("publish")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> PublishSistemaAsync([FromBody] PublishSistemaCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        /// <summary>
        /// Gera uma nova secret do Sistema
        /// </summary>    
        /// <param name="request"></param>                     
        /// <returns></returns>
        [HttpPut("credential")]
        [ProducesResponseType(typeof(SistemaCadastroDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateSistemaCredencialAsync([FromBody] UpdateSistemaCredencialCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        /// <summary>
        /// Deleta um registro de Sistema pelo Id
        /// </summary>    
        /// <param name="id"></param>                     
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteSistemaAsync(int id)
        {
            var query = new DeleteSistemaCommand(id);

            var response = await _mediator.Send(query);

            return Ok(response);
        }
        /// <summary>
        /// Rota de acesso pelas API's para obter as configurações do sistema 
        /// </summary>  
        /// <param name="ignoreCache"></param> 
        /// <returns></returns>
        [HttpGet("config/{ignoreCache?}")]
        [Authorize(Policy = "SistemaConfigPolicy")]
        public async Task<IActionResult> GetConfig(bool? ignoreCache)
        {
            var query = new GetSistemaConfigQuery(ignoreCache);

            var response = await _mediator.Send(query);

            if (response is null)
                return NoContent();

            return Ok(response);
        }
    }
}

using Application.Contracts.Seg;
using Application.ServiceAgent.Seg.Queries.GetSistemaByUsuario;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    [Route("api/seg")]
    [ApiController]
    [Authorize]
    public class SegController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SegController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Obtem a lista de sistemas autorizados para o usuário logado
        /// </summary>                          
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(SistemaSegDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSistemaByUsuarioAsync()
        {
            var query = new GetSistemaByUsuarioQuery();

            var response = await _mediator.Send(query);

            if (response is null)
                return NoContent();

            return Ok(response);
        }
    }
}

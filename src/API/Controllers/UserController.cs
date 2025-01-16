using Application.Commands.CreateUser;
using Application.Commands.UpdateUser;
using Application.Commands.UpdateUserCredential;
using Application.Contracts.User;
using Application.Queries.GetUser;
using Application.Queries.GetUserById;
using Domain.Helpers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/user")]
    [ApiController]
    //[Authorize(Policy = "BlackTiePolicy")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Obtem o user pelo ID
        /// </summary>                           
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserByIdAsync(Guid id)
        {
            var query = new GetUserByIdQuery(id);

            var response = await _mediator.Send(query);

            if (response is null)
                return NoContent();

            return Ok(response);
        }

        /// <summary>
        /// Obtem a lista de users
        /// </summary>                           
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(PagedList<UserDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserAsync([FromQuery] GetUserParameters parameters)
        {
            var query = new GetUserQuery(parameters);

            var response = await _mediator.Send(query);

            if (response is null)
                return NoContent();

            return Ok(response);
        }

        /// <summary>
        /// Cria um novo registro de User
        /// </summary>    
        /// <param name="request"></param>                     
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
        /// <summary>
        /// Atualiza um registro de User
        /// </summary>    
        /// <param name="request"></param>                     
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UpdateUserCommand request)
        {
            return Ok(await _mediator.Send(request));
        }       

        /// <summary>
        /// Gera uma nova secret do User
        /// </summary>    
        /// <param name="request"></param>                     
        /// <returns></returns>
        [HttpPut("credential")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateUserCredencialAsync([FromBody] UpdateUserCredentialCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        
        
    }
}


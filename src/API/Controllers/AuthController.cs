using Application.Contracts.User;
using Domain.Exceptions;
using Domain.Helpers;
using Domain.Interfaces.Authentication;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;
        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }
       

        /// <summary>
        /// Autenticação via credentials para obter as configurações da aplicação
        /// </summary>                           
        /// <returns></returns>
        [HttpPost("openid")]        
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        public IActionResult BasicAuthenticate()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return Unauthorized();
            }

            var authHeader = Request.Headers["Authorization"].ToString();
            if (!authHeader.StartsWith("Basic "))
            {
                return Unauthorized();
            }

            // Decodificar a parte do "Basic" auth
            var encodedEmailPassword = authHeader.Substring("Basic ".Length).Trim();
            var encoding = Encoding.GetEncoding("iso-8859-1");
            var emailPassword = encoding.GetString(Convert.FromBase64String(encodedEmailPassword));

            var email = emailPassword.Split(':')[0];
            var password = emailPassword.Split(':')[1];


            var user = _authService.BasicAuthenticate(email, password);

            if (user == null)
            {
                return Unauthorized();
            }

                return Ok(user.Adapt<UserDto>());
        }

        [HttpPost("openid/control/validate")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public IActionResult ControlValidate()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return Unauthorized();
            }

            var authHeader = Request.Headers["Authorization"].ToString();
            if (!authHeader.StartsWith("Basic "))
            {
                return Unauthorized();
            }

            // Decodificar a parte do "Basic" auth
            var encodedIdControl = authHeader.Substring("Basic ".Length).Trim();
            var encoding = Encoding.GetEncoding("iso-8859-1");
            var authControl = encoding.GetString(Convert.FromBase64String(encodedIdControl));

            var userId = authControl.Split(':')[0];
            var control = authControl.Split(':')[1];


            var valid = _authService.ValidateControl(Guid.Parse(userId), control).GetAwaiter().GetResult();
                        

            return Ok(valid);
        }

        [HttpPost("openid/control/resend")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public IActionResult ResendControl()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return Unauthorized();
            }

            var authHeader = Request.Headers["Authorization"].ToString();
            if (!authHeader.StartsWith("Basic "))
            {
                return Unauthorized();
            }

            // Decodificar a parte do "Basic" auth
            var encodedMailControl = authHeader.Substring("Basic ".Length).Trim();
            var encoding = Encoding.GetEncoding("iso-8859-1");
            var emailControl = encoding.GetString(Convert.FromBase64String(encodedMailControl));

            var control = emailControl.Split(':')[0];
            var email = emailControl.Split(':')[1];


            var valid = _authService.CreateControl(email).GetAwaiter().GetResult();

            if (!valid)
            {
                return Unauthorized();
            }

            return Ok(valid);
        }

        [HttpPost("openid/pass/generate")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public IActionResult CreatePassword()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return Unauthorized();
            }

            var authHeader = Request.Headers["Authorization"].ToString();
            if (!authHeader.StartsWith("Basic "))
            {
                return Unauthorized();
            }

            // Decodificar a parte do "Basic" auth
            var encodedIdPass = authHeader.Substring("Basic ".Length).Trim();
            var encoding = Encoding.GetEncoding("iso-8859-1");
            var control = encoding.GetString(Convert.FromBase64String(encodedIdPass));

            var userId = control.Split(':')[0];
            var password = control.Split(':')[1];


            var result = _authService.CreatePassword(Guid.Parse(userId), password).GetAwaiter().GetResult();
            
            if (!result)
            {
                return Unauthorized();
            }            

            return Ok(result);
        }
    }
}

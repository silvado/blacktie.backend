using Application.Commands.CreatePaymentType;
using Application.Contracts.PaymentType;
using Application.Queries.GetPaymentType;
using Domain.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/payment-type")]
    [ApiController]
    public class PaymentTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }


        /// <summary>
        /// Obtem a lista de paymenttypes
        /// </summary>                           
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(PagedList<PaymentTypeDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync([FromQuery] GetPaymentTypeParameters parameters)
        {
            var query = new GetPaymentTypeQuery(parameters);

            var response = await _mediator.Send(query);

            if (response is null)
                return NoContent();

            return Ok(response);
        }

        /// <summary>
        /// Cria um novo registro de PaymentType
        /// </summary>    
        /// <param name="request"></param>                     
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(PaymentTypeDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAsync([FromBody] CreatePaymentTypeCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

    }
}

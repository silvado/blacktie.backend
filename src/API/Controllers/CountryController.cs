using Application.Contracts.Country;
using Application.Queries.GetCountry;
using Domain.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/country")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PagedList<CountryDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCountrys([FromQuery] GetCountryParameters queryParameters)
        {
            var query = new GetCountryQuery(queryParameters);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}

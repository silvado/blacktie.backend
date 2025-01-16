using Application.Contracts.DocumentType;
using Application.Queries.GetDocumentType;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/document-type")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DocumentTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<DocumentTypeDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDocumentTypes()
        {
            var query = new GetDocumentTypeQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}

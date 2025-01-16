using Application.Abstractions.Messaging;
using Application.Contracts.DocumentType;
using Application.Queries.GetDocumentType;
using Domain.Interfaces.Repository;
using Mapster;

namespace Application.DocumentType.Queries.GetDocumentType
{
    public class GetDocumentTypeHandler : IQueryHandler<GetDocumentTypeQuery, List<DocumentTypeDto>?>
    {
        private readonly IDocumentTypeRepository _repository;

        public GetDocumentTypeHandler(IDocumentTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<DocumentTypeDto>?> Handle(GetDocumentTypeQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsync();

            if (result == null)
                return null;

            return result.Adapt<List<DocumentTypeDto>>(); ;
        }
    }
}

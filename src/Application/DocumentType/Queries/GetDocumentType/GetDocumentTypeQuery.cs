using Application.Abstractions.Messaging;
using Application.Contracts.DocumentType;

namespace Application.Queries.GetDocumentType
{
    public sealed record GetDocumentTypeQuery() : IQuery<List<DocumentTypeDto>?>;
}

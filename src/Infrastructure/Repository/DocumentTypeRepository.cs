using Domain.Interfaces.Repository;
using Domain.Models;
using Infrastructure.Context;
using Infrastructure.Repository.Common;

namespace Infrastructure.Repository
{
    public class DocumentTypeRepository : GenericAsyncRepository<DocumentType>, IDocumentTypeRepository
    {
        public DocumentTypeRepository(BlacktieDbContext dbContext) : base(dbContext)
        { }
    }
}

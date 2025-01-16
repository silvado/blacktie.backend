using Domain.Filters;
using Domain.Helpers;
using Domain.Interfaces.Common;
using Domain.Interfaces.Service;
using Domain.Models;
using System.Diagnostics.CodeAnalysis;

namespace Application.Services
{
    [ExcludeFromCodeCoverage]
    public class SistemaPublicacaoService : ISistemaPublicacaoService
    {
        private readonly IUnitOfWork _uow;

        public SistemaPublicacaoService(IUnitOfWork uow)
        {
            _uow = uow;
        }


        public async Task<PagedList<SistemaPublicacao>?> GetFilteredAsync(SistemaPublicacaoFilter filter)
        {
            var result = await _uow.SistemaPublicacaoRepository.GetFilteredAsync(filter);
            return result;
        }

        public async Task<SistemaPublicacao?> GetByIdAsync(int id)
        {
            var result = await _uow.SistemaPublicacaoRepository.GetByIdAsync(id);

            if (result == null) return null;

            result.Sistema = await _uow.SistemaRepository.GetByIdAsync(result.SistemaId);

            return result;
        }



    }
}

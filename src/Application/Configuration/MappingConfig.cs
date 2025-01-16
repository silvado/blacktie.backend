using Application.Contracts;
using Application.Contracts.Address;
using Application.Contracts.Customer;
using Application.Contracts.Seg;
using Application.Queries.GetSistemaPublicacao;
using Domain.Filters;
using Domain.Interfaces.ServiceAgent.DataContracts.Response;
using Domain.Models;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Application.Configuration
{
    public static class MappingConfig
    {
        [ExcludeFromCodeCoverage]
        public static void ConfigureMappings(this IServiceCollection services)
        {
            TypeAdapterConfig<SegSistema, SistemaSegDto>.NewConfig()
               .Map(dest => dest.Id, src => src.CodSistema)
               .Map(dest => dest.NomeSistema, src => src.NomeSist)
               .Map(dest => dest.SiglaSistema, src => src.SiglaSistema);
            
            TypeAdapterConfig<GetSistemaPublicacaoParameters, SistemaPublicacaoFilter>.NewConfig()
             .Map(dest => dest.NomeSistema, src => src.SearchTerm)
             .Map(dest => dest.PageNumber, src => src.PageNumber)
             .Map(dest => dest.PageSize, src => src.PageSize)
             .Map(dest => dest.IdSistema, src => string.IsNullOrEmpty(src.Id) ? (int?)null : int.Parse(src.Id));

            TypeAdapterConfig<SistemaPublicacao, SistemaPublicacaoDto>.NewConfig()
               .Map(dest => dest.SistemaId, src => src.SistemaId)
               .Map(dest => dest.Configuracao, src => src.Configuracao)
               .Map(dest => dest.PublishedAt, src => src.PublishedAt)
               .Map(dest => dest.PublishedByUserId, src => src.PublishedByUserId)
               .Map(dest => dest.Sistema, src => src.Sistema != null ? src.Sistema.Adapt<SistemaDto>() : null);

            //TypeAdapterConfig<Customer, CustomerDto>.NewConfig()               
            //   .Map(dest => dest.Addresses, src => src.CustomerAddresses != null ? src.CustomerAddresses.Select(me => me.Address).Adapt<IEnumerable<AddressDto>>() : null);

        }
    }
}

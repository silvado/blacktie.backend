using Application.Abstractions.Messaging;
using Application.Contracts;
using Application.Contracts.Customer;
using Domain.Entities.Abstracts;
using Domain.Exceptions;
using Domain.Helpers;
using Domain.Interfaces.Service;
using Domain.Models;
using Mapster;

namespace Application.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandle : ICommandHandler<UpdateCustomerCommand, ResultWrapper<Customer>>
    {
        private readonly ICustomerService _service;


        public UpdateCustomerCommandHandle(ICustomerService service)
        {
            _service = service;
        }

        public async Task<ResultWrapper<Customer>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {

            var modifiedCustomer = await _service.GetByIdAsync(request.item.Id);
            if (modifiedCustomer == null)
                throw new CustomerNotFoundException();

            request.item.Adapt(modifiedCustomer);

            // Atualizar Endereços
            UpdateCollection<Address, CreateEnderecoDto, CustomerAddress>(
                modifiedCustomer.CustomerAddresses,
                request.item.Addresses,
                dto => new Address // Criar Endereco
                {
                    Street = dto.Street,
                    City = dto.City,
                    PostalCode = dto.PostalCode,
                    CountryId = dto.CountryId,
                    Locality = dto.Locality,
                    Number = dto.Number,
                    Complement = dto.Complement,
                    RegionCode = dto.RegionCode
                },
                link => link.Address, // Extrair Endereco de CustomerEndereco
                (link, address) => { link.Address = address; link.Customer = modifiedCustomer; });

            return await _service.UpdateAsync(modifiedCustomer);

        }

        private void UpdateCollection<T, TDto, TLink>(ICollection<TLink> linkCollection, IEnumerable<TDto> dtoCollection, Func<TDto, T> createEntity, Func<TLink, T> getEntityFromLink, Action<TLink, T> linkToEntity)
       where T : EntityInt, new()
       where TDto : DtoBaseInt
       where TLink : class, new()
        {
            var entityMap = linkCollection.ToDictionary(e => getEntityFromLink(e).Id);

            foreach (var dto in dtoCollection)
            {
                if (dto.Id == 0 || !entityMap.ContainsKey(dto.Id))
                {
                    // Criar nova entidade e novo link
                    var newEntity = createEntity(dto);
                    var newLink = new TLink();
                    linkToEntity(newLink, newEntity);
                    linkCollection.Add(newLink);
                }
                else if (entityMap.TryGetValue(dto.Id, out var link))
                {
                    // Atualizar entidade existente
                    var entity = getEntityFromLink(link);
                    dto.Adapt(entity);
                }
            }

            // Remover links para entidades não presentes nos DTOs
            var dtoIds = new HashSet<int>(dtoCollection.Select(d => d.Id));
            var linksToRemove = linkCollection.Where(e => !dtoIds.Contains(getEntityFromLink(e).Id)).ToList();
            foreach (var link in linksToRemove)
            {
                linkCollection.Remove(link);
            }
        }
    }
}

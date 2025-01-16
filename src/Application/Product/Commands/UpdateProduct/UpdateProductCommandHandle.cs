using Application.Abstractions.Messaging;
using Domain.Interfaces.Service;
using Domain.Models;
using Mapster;

namespace Application.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, bool>
    {
        private readonly IProductService _service;


        public UpdateProductCommandHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            var r = request.item.Adapt<Product>();

            return (await _service.UpdateAsync(r));

        }
    }
}

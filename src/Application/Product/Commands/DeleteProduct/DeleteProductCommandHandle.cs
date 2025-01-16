using Application.Abstractions.Messaging;
using Application.Commands.DeleteProduct;
using Domain.Interfaces.Service;

namespace Application.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand, bool>
    {
        private readonly IProductService _service;

        public DeleteProductCommandHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {

            return await _service.DeleteAsync(request.id);

        }
    }
}

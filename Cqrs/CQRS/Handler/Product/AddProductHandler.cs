using System.Threading;
using System.Threading.Tasks;
using Cqrs.CQRS.Commands.Product;
using Cqrs.Repository;
using MediatR;

namespace Cqrs.CQRS.Handler.Product
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Models.Product>
    {
        private readonly IProductRepository _productRepository;

        public AddProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public async Task<Models.Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            return await _productRepository.Add(request.Title, request.Quantity);
        }
    }
}
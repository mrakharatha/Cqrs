using System.Threading;
using System.Threading.Tasks;
using Cqrs.CQRS.Query.Product;
using Cqrs.Repository;
using MediatR;

namespace Cqrs.CQRS.Handler.Product
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Models.Product>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Models.Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(request.Id);
            return product;
        }
    }
}
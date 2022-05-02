using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cqrs.CQRS.Query.Product;
using Cqrs.Repository;
using MediatR;

namespace Cqrs.CQRS.Handler.Product
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<Models.Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Models.Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAll();
            return products;
        }
    }
}
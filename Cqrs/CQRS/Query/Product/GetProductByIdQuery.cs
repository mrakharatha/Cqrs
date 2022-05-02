using MediatR;

namespace Cqrs.CQRS.Query.Product
{
    public class GetProductByIdQuery : IRequest<Models.Product>
    {
        public int Id { get; }

        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
using System.Collections.Generic;
using MediatR;

namespace Cqrs.CQRS.Query.Product
{

    public class GetAllProductsQuery : IRequest<List<Models.Product>>
    {


    }
}
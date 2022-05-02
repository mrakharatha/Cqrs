using System.Threading.Tasks;
using Cqrs.CQRS.Commands.Product;
using Cqrs.CQRS.Query.Product;
using Cqrs.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cqrs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _mediator;

        public ProductsController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            return product != null ? Ok(product) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddProduct newProduct)
        {
            var product = await _mediator.Send(new AddProductCommand(newProduct.Title, newProduct.Quantity));
            return product != null ? Created($"/product/{product.Id}", product) : BadRequest();
        }

    }
}

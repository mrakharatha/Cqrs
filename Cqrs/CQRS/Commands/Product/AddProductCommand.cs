using MediatR;

namespace Cqrs.CQRS.Commands.Product
{
    public class AddProductCommand : IRequest<Models.Product>
    {
        public string Title { get; }
        public int Quantity { get; }

        public AddProductCommand(string title, int quantity)
        {
            Title = title;
            Quantity = quantity;
        }
    }
}
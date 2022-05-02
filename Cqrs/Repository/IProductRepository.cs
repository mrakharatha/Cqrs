using System.Collections.Generic;
using System.Threading.Tasks;
using Cqrs.Models;

namespace Cqrs.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<Product> Add(string title, int quantity);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Cqrs.Context;
using Cqrs.Models;
using Cqrs.Repository;
using Microsoft.EntityFrameworkCore;

namespace Cqrs.Service
{
    public class ProductRepository : IProductRepository
    {
        private readonly CqrsContext _context;

        public ProductRepository(CqrsContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> Add(string title, int quantity)
        {
            Product product = new Product()
            {
                Title = title,
                Quantity = quantity
            };

            await _context.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }
    }
}
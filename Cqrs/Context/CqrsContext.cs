using System.Linq;
using Cqrs.Models;
using Microsoft.EntityFrameworkCore;

namespace Cqrs.Context
{
    public class CqrsContext : DbContext
    {
        public CqrsContext(DbContextOptions<CqrsContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;


            base.OnModelCreating(modelBuilder);
        }
    }
}

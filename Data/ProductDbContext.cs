using Microsoft.EntityFrameworkCore;
using WebApiBeta.Models;

namespace WebApiBeta.Data
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions options) :base(options)
        {
            
        }
        public DbSet<ProductEntity> Products { get; set; }

    }


}

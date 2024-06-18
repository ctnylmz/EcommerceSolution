using Microsoft.EntityFrameworkCore;
using Shareds.Models;

namespace WebApi.Data
{
    public class EcommerceSolutionContext : DbContext
    {
        public EcommerceSolutionContext(DbContextOptions<EcommerceSolutionContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}

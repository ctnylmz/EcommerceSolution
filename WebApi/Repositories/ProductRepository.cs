using Microsoft.EntityFrameworkCore;
using Shareds.Contracts;
using Shareds.Models;
using Shareds.Response;
using WebApi.Data;

namespace WebApi.Repositories
{
    public class ProductRepository : IProduct
    {
        private readonly EcommerceSolutionContext _context;

        public ProductRepository(EcommerceSolutionContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse> AddProduct(Product model)
        {
            if (model is null) return new ServiceResponse(false, "Model is null");
            var (flag,message) = await CheckName(model.Name);
            if (flag)
            {
                _context.Add(model);
                await Commit();
                return new ServiceResponse(true, "Product Saved");
            }
            return new ServiceResponse(false, message);
        }

        public async Task<List<Product>> GetAllProduct(bool featuredProducts)
        {
            if (featuredProducts)
                return await _context.Products.Where(x => x.Featured).ToListAsync();
            else 
                return await _context.Products.ToListAsync();
        }

        private async Task<ServiceResponse> CheckName(string name)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Name.ToLower()!.Equals(name.ToLower()));
            return product is null ? new ServiceResponse(true, null!) : new ServiceResponse(false, "Product alredy exit");
        }

        private async Task Commit() => await _context.SaveChangesAsync();
    }
}

using Microsoft.EntityFrameworkCore;
using ShoppingWebApp.Data;
using ShoppingWebApp.IServices;
using ShoppingWebApp.Models;

namespace ShoppingWebApp.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductModel>> GetAllProductsAsync()
        {
            return await _context.Products
                         .Include(p => p.Category)  // Category ile birlikte yükleniyor
                         .ToListAsync();
        }

        public async Task<ProductModel> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task AddProductAsync(ProductModel product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(ProductModel product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}

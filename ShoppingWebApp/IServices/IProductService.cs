using ShoppingWebApp.Models;

namespace ShoppingWebApp.IServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetAllProductsAsync();
        Task<ProductModel> GetProductByIdAsync(int id);
        Task AddProductAsync(ProductModel product);
        Task UpdateProductAsync(ProductModel product);
        Task DeleteProductAsync(int id);
        Task<IEnumerable<Category>> GetCategories();
    }
}

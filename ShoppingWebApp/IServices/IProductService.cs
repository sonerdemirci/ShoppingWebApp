﻿using ShoppingWebApp.Models;

namespace ShoppingWebApp.IServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
        Task<IEnumerable<Category>> GetCategories();
    }
}

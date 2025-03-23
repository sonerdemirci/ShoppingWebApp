using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingWebApp.IServices;
using ShoppingWebApp.Models;
using ShoppingWebApp.ViewModels.Product;

namespace ShoppingWebApp.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await _productService.GetCategories();
            var model = new CreateViewModel
            {
                Categories = categories.Select(c => new SelectListItem
                {
                    Value = c.CategoryID.ToString(),
                    Text = c.CategoryName
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateViewModel model)
        {

            if (!ModelState.IsValid)
            {
                var categories = await _productService.GetCategories();
                model.Categories = categories.Select(c => new SelectListItem
                {
                    Value = c.CategoryID.ToString(),
                    Text = c.CategoryName
                }).ToList();

                return View(model);
            }

            var product = new ProductModel
            {
                ProductName = model.ProductName,
                Price = model.Price,
                CategoryID = model.CategoryID == null ? 0 : model.CategoryID.Value
            };

            await _productService.AddProductAsync(product);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var model = new EditViewModel
            {
                product = product
                
            };


            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var model = new DetailsViewModel
            {
                product = product

            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            await _productService.DeleteProductAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

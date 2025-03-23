using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShoppingWebApp.ViewModels.Product
{
    public class CreateViewModel
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Lütfen ürün adı girin")]
        public string ProductName { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Fiyat 0'dan büyük olmalıdır")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Lütfen bir kategori seçin")]
        public int? CategoryID { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
    }
}

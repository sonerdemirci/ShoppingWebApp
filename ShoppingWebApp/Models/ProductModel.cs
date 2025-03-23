using System.ComponentModel.DataAnnotations;

namespace ShoppingWebApp.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}

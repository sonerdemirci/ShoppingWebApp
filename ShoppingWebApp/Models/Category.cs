namespace ShoppingWebApp.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<ProductModel> Products { get; set; }
    }
}

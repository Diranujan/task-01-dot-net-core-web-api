namespace Backend.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public ICollection<Subcategory> Subcategories { get; set; }=new List<Subcategory>();    
        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}

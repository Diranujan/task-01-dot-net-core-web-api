namespace Backend.Models
{
    public class Subcategory
    {
        public int SubcategoryId { get; set; }
        public string SubcategoryName { get; set; }=string.Empty;
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();


    }
}

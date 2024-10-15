namespace Backend.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; }=string.Empty;
        public int CategoryId { get; set; }
        public Category? Category { get; set; } = null!;
        public int SubcategoryId { get; set; }
        public Subcategory? Subcategory { get; set; }=null!;
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
        public ICollection<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();
        public ICollection<ProductColor> ProductColors { get; set; }=new List<ProductColor>();
        public ICollection<Image> Images { get; set; } = new List<Image>();
    }
}

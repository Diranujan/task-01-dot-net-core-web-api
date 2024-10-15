using Backend.Dtos.Image;
using Backend.Dtos.ProductColor;
using Backend.Dtos.ProductSize;

namespace Backend.Dtos.Product
{
    public class ProductCreateDto
    {
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }
        public int BrandId { get; set; }
        public List<int> SizeIds { get; set; } = new List<int>();
        public List<int> ColorIds { get; set; } = new List<int>();

    }
}

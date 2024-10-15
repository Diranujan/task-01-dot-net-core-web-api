using Backend.Dtos.Image;
using Backend.Dtos.ProductColor;
using Backend.Dtos.ProductSize;
using Backend.Models;

namespace Backend.Dtos.Product
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }
        public int BrandId { get; set; }

        
        public List<ProductColorDto> ProductColors { get; set; } = new List<ProductColorDto>(); 
        public List<ProductSizeDto> ProductSizes { get; set; } = new List<ProductSizeDto>();
        public List<ImageDto> Images { get; set; } = new List<ImageDto>();
    }
}

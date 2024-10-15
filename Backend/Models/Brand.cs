using Microsoft.Extensions.Hosting;

namespace Backend.Models
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public string? BrandDescription { get; set;} = string.Empty;
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}

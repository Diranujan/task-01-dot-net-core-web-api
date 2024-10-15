namespace Backend.Models
{
    public class Size
    {
        public int SizeId { get; set; }
        public string SizeName { get; set; } = string.Empty;
        public ICollection<ProductSize> ProductSizes { get; set; }=new List<ProductSize>();

    }
}

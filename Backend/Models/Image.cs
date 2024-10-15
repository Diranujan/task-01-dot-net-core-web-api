namespace Backend.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}

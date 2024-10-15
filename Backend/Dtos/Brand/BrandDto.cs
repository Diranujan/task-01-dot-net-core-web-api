namespace Backend.Dtos.Brand
{
    public class BrandDto
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public string? BrandDescription { get; set; } = string.Empty;
    }
}

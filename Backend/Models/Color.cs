namespace Backend.Models
{
    public class Color
    {
        public int ColorId { get; set; }
        public string ColorName { get; set; }=string.Empty;
        public ICollection<ProductColor> ProductColors { get; set; } = new List<ProductColor>();

    }
}

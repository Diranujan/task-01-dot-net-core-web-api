namespace Backend.Dtos.Subcategory
{
    public class SubcategoryDto
    {
        public int SubcategoryId { get; set; }
        public string SubcategoryName { get; set; } = string.Empty;
        public int CategoryId { get; set; }
    }
}

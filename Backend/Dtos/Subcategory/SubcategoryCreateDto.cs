namespace Backend.Dtos.Subcategory
{
    public class SubcategoryCreateDto
    {
        public string SubcategoryName { get; set; } = string.Empty;
        public int CategoryId { get; set; }
    }
}

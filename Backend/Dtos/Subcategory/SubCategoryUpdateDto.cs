namespace Backend.Dtos.Subcategory
{
    public class SubCategoryUpdateDto
    {
        public string SubcategoryName { get; set; } = string.Empty;
        public int CategoryId { get; set; }
    }
}

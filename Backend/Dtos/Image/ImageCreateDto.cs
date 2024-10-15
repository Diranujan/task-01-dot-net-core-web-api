namespace Backend.Dtos.Image
{
    public class ImageCreateDto
    {
        public List<IFormFile> Images { get; set; } = new List<IFormFile>();
    }
}

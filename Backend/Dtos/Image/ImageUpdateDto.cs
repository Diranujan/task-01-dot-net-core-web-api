namespace Backend.Dtos.Image
{
    public class ImageUpdateDto
    {
        public List<IFormFile> Images { get; set; } = new List<IFormFile>();
    }
}

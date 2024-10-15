using Backend.Dtos.Image;
using Backend.Dtos.ProductColor;
using Backend.Dtos.ProductSize;
using Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync(); 
        Task<Product?> GetByIdAsync(int id);  
        Task<Product> CreateAsync(Product product);  
        Task<Product?> UpdateAsync(Product product);  
        Task<Product?> DeleteAsync(int id);
        Task<List<Image>> ProcessImagesAsync(List<IFormFile> images);
        
    }
}

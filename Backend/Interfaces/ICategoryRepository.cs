using Backend.Dtos.Category;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task<Category> CreateAsync(Category categoryModel);
        Task<Category> UpdateAsync(Category category);
        Task<Category?> DeleteAsync(int id);
    }
}

using Backend.Models;

namespace Backend.Interfaces
{
    public interface ISubcategoryRepository
    {
        Task<List<Subcategory>> GetAllAsync();
        Task<Subcategory?> GetByIdAsync(int id);
        Task<Subcategory> CreateAsync(Subcategory subcategory);
        Task<Subcategory> UpdateAsync(Subcategory subcategory); 
        Task<Subcategory?> DeleteAsync(int id);
        Task<List<Subcategory>> GetByCategoryIdAsync(int categoryId);
    }
}

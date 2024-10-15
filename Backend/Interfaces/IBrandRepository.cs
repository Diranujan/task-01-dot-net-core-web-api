using Backend.Models;

namespace Backend.Interfaces
{
    public interface IBrandRepository
    {
        Task<List<Brand>> GetAllAsync();
        Task<Brand?> GetByIdAsync(int id);
        Task<Brand> CreateAsync(Brand brandModel);  
        Task<Brand> UpdateAsync(Brand brand);
        Task<Brand?> DeleteAsync(int id);
    }
}

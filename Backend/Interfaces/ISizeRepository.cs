using Backend.Models;

namespace Backend.Interfaces
{
    public interface ISizeRepository
    {
        Task<List<Size>> GetAllAsync();
        Task<Size?> GetByIdAsync(int id);
        Task<Size> CreateAsync(Size sizeModel);
        Task<Size> UpdateAsync(Size sizeModel);
        Task<Size?> DeleteAsync(int id);
    }
}

using Backend.Models;

namespace Backend.Interfaces
{
    public interface IColorRepository
    {
        Task<List<Color>> GetAllAsync();
        Task<Color?> GetByIdAsync(int id);
        Task<Color> CreateAsync(Color colorModel);
        Task<Color> UpdateAsync(Color colorModel);
        Task<Color?> DeleteAsync(int id);
    }
}

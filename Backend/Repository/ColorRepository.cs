using Backend.Data;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class ColorRepository : IColorRepository
    {
        private readonly ApplicationDBContext _context;
        public ColorRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Color> CreateAsync(Color colorModel)
        {
            await _context.Colors.AddAsync(colorModel);
            await _context.SaveChangesAsync();
            return colorModel;
        }

        public async Task<Color?> DeleteAsync(int id)
        {
            var colorModel = await _context.Colors.FindAsync(id);
            if (colorModel == null)
            {
                return null;
            }
            _context.Colors.Remove(colorModel); 
            await _context.SaveChangesAsync();
            return colorModel;
        }


        public async Task<List<Color>> GetAllAsync()
        {
            return await _context.Colors.ToListAsync();
            
        }

        public async Task<Color?> GetByIdAsync(int id)
        {
            return await _context.Colors.FirstOrDefaultAsync(c => c.ColorId == id);
        }

        public async Task<Color> UpdateAsync(Color colorModel)
        {

            _context.Colors.Update(colorModel);
            await _context.SaveChangesAsync();
            return colorModel;
        }
    }
}

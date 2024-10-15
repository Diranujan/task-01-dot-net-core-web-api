using Backend.Data;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace Backend.Repository
{
    public class SizeRepository : ISizeRepository
    {
        private readonly ApplicationDBContext _context;
        public SizeRepository(ApplicationDBContext  context) 
        { 
            _context = context;
        }

        public async Task<Models.Size> CreateAsync(Models.Size sizeModel)
        {
            await _context.Sizes.AddAsync(sizeModel);
            await _context.SaveChangesAsync();
            return sizeModel;
        }

        public async Task<Models.Size?> DeleteAsync(int id)
        {
            var sizeModel = await _context.Sizes.FindAsync(id);

            if (sizeModel == null)
            {
                return null;
            }
            _context.Sizes.Remove(sizeModel);
            await _context.SaveChangesAsync();
            return sizeModel;
        }

        public async Task<List<Models.Size>> GetAllAsync()
        {
            return await _context.Sizes.ToListAsync();
        }

        public async Task<Models.Size?> GetByIdAsync(int id)
        {
            return await _context.Sizes.FirstOrDefaultAsync(i => i.SizeId == id);
        }

        public async Task<Models.Size> UpdateAsync(Models.Size sizeModel)
        {
            _context.Sizes.Update(sizeModel);
            await _context.SaveChangesAsync();
            return sizeModel;
        }
    }
}

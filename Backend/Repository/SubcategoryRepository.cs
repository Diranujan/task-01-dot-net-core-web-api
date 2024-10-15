using Backend.Data;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class SubcategoryRepository : ISubcategoryRepository
    {
        private readonly ApplicationDBContext _context;
        public SubcategoryRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Subcategory> CreateAsync(Subcategory subcategory)
        {
            await _context.Subcategories.AddAsync(subcategory);
            await _context.SaveChangesAsync();
            return subcategory;
        }

        public async Task<Subcategory?> DeleteAsync(int id)
        {
            var subcategoryModel= await _context.Subcategories.FindAsync(id);
            if (subcategoryModel == null)
            {
                return null;
            }
            _context.Subcategories.Remove(subcategoryModel);
            await _context.SaveChangesAsync();
            return subcategoryModel;
        }

        public async Task<List<Subcategory>> GetAllAsync()
        {
           return await _context.Subcategories.ToListAsync();
        }

        public async Task<List<Subcategory>> GetByCategoryIdAsync(int categoryId)
        {
            return await _context.Subcategories.Where(s => s.CategoryId == categoryId).ToListAsync();
        }

        public Task<Subcategory?> GetByIdAsync(int id)
        {
            return _context.Subcategories.FirstOrDefaultAsync(i => i.SubcategoryId == id);
        }

        public async Task<Subcategory> UpdateAsync(Subcategory subcategory)
        {
            _context.Subcategories.Update(subcategory);
            await _context.SaveChangesAsync();
            return subcategory;
        }
    }
}

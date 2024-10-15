using Backend.Data;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ApplicationDBContext _context;
        public BrandRepository(ApplicationDBContext context)    
        {
            _context = context;
        }
        public async Task<Brand> CreateAsync(Brand brandModel)
        {
            await _context.Brands.AddAsync(brandModel);
            await _context.SaveChangesAsync();
            return brandModel;
        }

        public async Task<Brand?> DeleteAsync(int id)
        {
            var brandModel = await _context.Brands.FindAsync(id);
            if (brandModel == null)
            {
                return null;
            }
            _context.Brands.Remove(brandModel);
            await _context.SaveChangesAsync();
            return brandModel;
        }

        public async Task<List<Brand>> GetAllAsync()
        {
            return await _context.Brands.ToListAsync();
        }

        public async Task<Brand?> GetByIdAsync(int id)
        {
            return await _context.Brands.FirstOrDefaultAsync(b => b.BrandId == id);
        }

        public async Task<Brand> UpdateAsync(Brand brand)
        {
            _context.Brands.Update(brand);
            await _context.SaveChangesAsync();
            return brand;
        }
    }
}

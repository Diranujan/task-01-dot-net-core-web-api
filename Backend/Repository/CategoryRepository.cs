using AutoMapper;
using Backend.Data;
using Backend.Dtos.Category;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _context;
        public CategoryRepository(ApplicationDBContext context)
        { 
            _context = context;
        }

        public async Task<Category> CreateAsync(Category categoryModel)
        {
            await _context.Categories.AddAsync(categoryModel);
            await _context.SaveChangesAsync();
            return categoryModel;
        }

        public async Task<Category?> DeleteAsync(int id)
        {
            var categoryModel = await _context.Categories.FindAsync(id);
           
            if (categoryModel == null)
            {
                return null;
            }
            _context.Categories.Remove(categoryModel);
            await _context.SaveChangesAsync();
            return categoryModel;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(i => i.CategoryId == id);

        }

        public async Task<Category> UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }

    }
}

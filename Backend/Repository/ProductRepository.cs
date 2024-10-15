using Backend.Data;
using Backend.Dtos.Color;
using Backend.Dtos.Image;
using Backend.Dtos.Product;
using Backend.Dtos.ProductColor;
using Backend.Dtos.ProductSize;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly IWebHostEnvironment _environment;

        public ProductRepository(ApplicationDBContext context,IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

      
        public async Task<Product> CreateAsync(Product productModel)
        {

            await _context.Products.AddAsync(productModel);
            await _context.SaveChangesAsync();
            return productModel;
        }


        public async Task<Product?> DeleteAsync(int id)
        {
            var productModel = await _context.Products
                .Include(p => p.Images)
                .Include(p => p.ProductSizes)
                .Include(p => p.ProductColors)
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (productModel == null)
            {
                return null;
            }

            _context.Images.RemoveRange(productModel.Images);
            _context.Products.Remove(productModel);
            await _context.SaveChangesAsync();
            return productModel;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products
                .Include(p => p.Images)
                .Include(p => p.ProductSizes)
                .Include(p => p.ProductColors)
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Images)
                .Include(p => p.ProductSizes)
                .Include(p => p.ProductColors)
                .FirstOrDefaultAsync(p => p.ProductId == id);
        }

       

        public async Task<List<Image>> ProcessImagesAsync(List<IFormFile> images)
        {
            var imageList = new List<Image>();
            string wwwRootPath = _environment.WebRootPath;

            if (string.IsNullOrEmpty(wwwRootPath))
            {
                throw new InvalidOperationException("Web root path is not set.");
            }

            string imagesPath = Path.Combine(wwwRootPath, "images");

            if (!Directory.Exists(imagesPath))
            {
                Directory.CreateDirectory(imagesPath);
            }

            foreach (var image in images)
            {
                if (image.Length > 0)
                {
                    string fileName = Path.GetRandomFileName() + Path.GetExtension(image.FileName);
                    string filePath = Path.Combine(imagesPath, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }

                    imageList.Add(new Image { ImagePath = "/images/" + fileName });
                }
            }

            return imageList;
        }



        public async Task<Product?> UpdateAsync(Product productModel)
        {
            _context.Products.Update(productModel);
            await _context.SaveChangesAsync();
            return productModel;
        }

    }
}

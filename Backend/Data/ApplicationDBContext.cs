using Backend.Models;
using Backend.Seeders;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
            :base(dbContextOptions)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductSize>()
                .HasKey(ps => new { ps.ProductId, ps.SizeId });
            modelBuilder.Entity<ProductSize>()
                .HasOne(p => p.Product)
                .WithMany(ps => ps.ProductSizes)
                .HasForeignKey(p => p.ProductId);
            modelBuilder.Entity<ProductSize>()
               .HasOne(s => s.Size)
               .WithMany(ps => ps.ProductSizes)
               .HasForeignKey(s => s.SizeId);


            modelBuilder.Entity<ProductColor>()
                .HasKey(pc => new { pc.ProductId, pc.ColorId });
            modelBuilder.Entity<ProductColor>()
                .HasOne(c => c.Color)
                .WithMany(pc => pc.ProductColors)
                .HasForeignKey(c => c.ColorId);
            modelBuilder.Entity<ProductColor>()
                .HasOne(p => p.Product)
                .WithMany(pc => pc.ProductColors)
                .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<Product>()
               .HasOne(p => p.Category)
               .WithMany(c => c.Products)
               .HasForeignKey(p => p.CategoryId)
               .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Brand)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.BrandId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Subcategory)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SubcategoryId)
                .OnDelete(DeleteBehavior.Restrict);


            CategorySeeder.Seed(modelBuilder);
            SubcategorySeeder.Seed(modelBuilder);
            BrandSeeder.Seed(modelBuilder);
            ColorSeeder.Seed(modelBuilder);
            SizeSeeder.Seed(modelBuilder);
        }
         
    }
}

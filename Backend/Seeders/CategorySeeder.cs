using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Seeders
{
    public static class CategorySeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasData(
                    new Category { CategoryId=1, CategoryName="Electronics"},
                    new Category { CategoryId=2, CategoryName="Clothing"},
                    new Category { CategoryId=3, CategoryName="Vehiles"}
                );
        }
    }
}

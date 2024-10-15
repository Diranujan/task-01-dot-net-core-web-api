using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Seeders
{
    public static class SubcategorySeeder
    {
        public static void Seed(ModelBuilder modelBuilder)  
        {
            modelBuilder.Entity<Subcategory>()
                .HasData(
                    new Subcategory { SubcategoryId = 1, SubcategoryName = "Mobile Phones", CategoryId = 1 },
                    new Subcategory { SubcategoryId = 2, SubcategoryName = "Laptops", CategoryId = 1 },
                    new Subcategory { SubcategoryId = 3, SubcategoryName = "Tablets", CategoryId = 1 },
 
                    new Subcategory { SubcategoryId = 4, SubcategoryName = "Men's Clothing", CategoryId = 2 },
                    new Subcategory { SubcategoryId = 5, SubcategoryName = "Women's Clothing", CategoryId = 2 },
                    new Subcategory { SubcategoryId = 6, SubcategoryName = "Children's Clothing", CategoryId = 2 },

                    new Subcategory { SubcategoryId = 7, SubcategoryName = "Cars", CategoryId = 3 },
                    new Subcategory { SubcategoryId = 8, SubcategoryName = "Motorcycles", CategoryId = 3 },
                    new Subcategory { SubcategoryId = 9, SubcategoryName = "Bicycles", CategoryId = 3 }
                );
        }
    }
}

using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Seeders
{
    public class BrandSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .HasData(
                    new Brand { BrandId = 1, BrandName = "Apple", BrandDescription = "Technology company specializing in consumer electronics." },
                    new Brand { BrandId = 2, BrandName = "Samsung", BrandDescription = "Leading manufacturer of consumer electronics and appliances." },
                    new Brand { BrandId = 3, BrandName = "Sony", BrandDescription = "Multinational corporation known for its electronics and entertainment." },

                    new Brand { BrandId = 4, BrandName = "Nike", BrandDescription = "Leading global brand in sports apparel and footwear." },
                    new Brand { BrandId = 5, BrandName = "Adidas", BrandDescription = "Renowned for its sportswear and lifestyle products." },
                    new Brand { BrandId = 6, BrandName = "Zara", BrandDescription = "Fashion retailer known for its trendy clothing and accessories." },

                    new Brand { BrandId = 7, BrandName = "Toyota", BrandDescription = "Renowned automobile manufacturer known for reliability." },
                    new Brand { BrandId = 8, BrandName = "Ford", BrandDescription = "American multinational automaker with a rich history." },
                    new Brand { BrandId = 9, BrandName = "BMW", BrandDescription = "German luxury vehicle manufacturer known for performance and innovation." }
                 );
        }
    }
}

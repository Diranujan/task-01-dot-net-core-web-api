using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Seeders
{
    public class SizeSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Size>()
                .HasData(
                    new Size { SizeId = 1, SizeName = "Small" },
                    new Size { SizeId = 2, SizeName = "Medium" },
                    new Size { SizeId = 3, SizeName = "Large" },
                    new Size { SizeId = 4, SizeName = "X-Large" },
                    new Size { SizeId = 5, SizeName = "XX-Large" }
                );

        }
    }
}

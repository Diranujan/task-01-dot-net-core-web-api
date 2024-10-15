using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Seeders
{
    public class ColorSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>()
                .HasData(
                    new Color { ColorId = 1, ColorName = "Red", },
                    new Color { ColorId = 2, ColorName = "Green" },
                    new Color { ColorId = 3, ColorName = "Blue" },
                    new Color { ColorId = 4, ColorName = "Yellow" },
                    new Color { ColorId = 5, ColorName = "Black" },
                    new Color { ColorId = 6, ColorName = "White" }
                );

        }
    }
}

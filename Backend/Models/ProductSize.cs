﻿namespace Backend.Models
{
    public class ProductSize
    {
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public Product Product { get; set; } = null!;
        public Size Size { get; set; } = null!;

    }
}

using AutoMapper;
using Backend.Dtos.Category;
using Backend.Dtos.Image;
using Backend.Dtos.Product;
using Backend.Dtos.ProductColor;
using Backend.Dtos.ProductSize;
using Backend.Interfaces;
using Backend.Models;
using Backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public ProductController(IProductRepository productRepo, IMapper mapper, IWebHostEnvironment environment)
        {
            _productRepo = productRepo;
            _mapper = mapper;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productRepo.GetAllAsync();
            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var product = await _productRepo.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            var productDto = _mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }





        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductCreateDto productDto,ImageCreateDto imageCreateDto)
        {
            if (productDto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = new Product
            {
                ProductName = productDto.ProductName,
                ProductDescription = productDto.ProductDescription,
                CategoryId = productDto.CategoryId,
                SubcategoryId = productDto.SubcategoryId,
                BrandId = productDto.BrandId,
                ProductSizes = productDto.SizeIds.Select(sizeId => new ProductSize{ SizeId = sizeId }).ToList(),
                ProductColors = productDto.ColorIds.Select(colorId => new ProductColor{ColorId = colorId }).ToList(),
            };


            if (imageCreateDto.Images != null && imageCreateDto.Images.Count > 0)
            {
                product.Images = await _productRepo.ProcessImagesAsync(imageCreateDto.Images);
            }

            var createdProduct = await _productRepo.CreateAsync(product);

            var createdProductDto = new ProductDto
            {
                ProductId = createdProduct.ProductId,
                ProductName = createdProduct.ProductName,
                ProductDescription = createdProduct.ProductDescription,
                CategoryId = createdProduct.CategoryId,
                SubcategoryId = createdProduct.SubcategoryId,
                BrandId = createdProduct.BrandId,
                ProductColors = createdProduct.ProductColors.Select(c => new ProductColorDto { ColorId = c.ColorId }).ToList(),
                ProductSizes = createdProduct.ProductSizes.Select(s => new ProductSizeDto { SizeId = s.SizeId }).ToList(),
                Images = createdProduct.Images.Select(i => new ImageDto { ImagePath = i.ImagePath }).ToList()
            };

            return CreatedAtAction(nameof(GetById), new { id = createdProduct.ProductId }, createdProductDto);
        }





        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] ProductUpdateDto productUpdateDto, [FromForm] ImageUpdateDto imageUpdate)
        {
            var existingProduct = await _productRepo.GetByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _mapper.Map(productUpdateDto, existingProduct);


            existingProduct.ProductSizes = productUpdateDto.SizeIds.Select(sizeId => new ProductSize { SizeId = sizeId }).ToList();

            existingProduct.ProductColors = productUpdateDto.ColorIds.Select(colorId => new ProductColor { ColorId = colorId }).ToList();

            if (imageUpdate.Images != null && imageUpdate.Images.Count > 0)
            {
                existingProduct.Images = await _productRepo.ProcessImagesAsync(imageUpdate.Images);
            }

            await _productRepo.UpdateAsync(existingProduct);

            var updatedProductDto = _mapper.Map<ProductDto>(existingProduct);

            return Ok(updatedProductDto);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deletedProduct = await _productRepo.DeleteAsync(id);

            if (deletedProduct == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

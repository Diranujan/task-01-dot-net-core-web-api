using AutoMapper;
using Backend.Dtos.Brand;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/brand")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandRepository _brandRepo;
        private readonly IMapper _mapper;

        public BrandController(IBrandRepository brandRepo, IMapper mapper)
        {
            _brandRepo = brandRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var brands = await _brandRepo.GetAllAsync();
            var brandDtos = _mapper.Map<IEnumerable<BrandDto>>(brands);
            return Ok(brandDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var brand = await _brandRepo.GetByIdAsync(id);

            if (brand == null)
            {
                return NotFound();
            }

            var brandDto = _mapper.Map<BrandDto>(brand);
            return Ok(brandDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BrandCreateDto brandCreateDto) 
        {
            var brandModel = _mapper.Map<Brand>(brandCreateDto);
            await _brandRepo.CreateAsync(brandModel);
            var brandDto = _mapper.Map<BrandDto>(brandModel);

            return CreatedAtAction(nameof(GetById), new { id = brandDto.BrandId}, brandDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BrandUpdateDto brandUpdateDto)
        {
            var existingBrand = await _brandRepo.GetByIdAsync(id);
            if (existingBrand == null)
            {
                return NotFound();
            }

            _mapper.Map(brandUpdateDto, existingBrand);
            await _brandRepo.UpdateAsync(existingBrand);

            var updatedBrandDto = _mapper.Map<BrandDto>(existingBrand);
            return Ok(updatedBrandDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deletedBrand = await _brandRepo.DeleteAsync(id);

            if (deletedBrand == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

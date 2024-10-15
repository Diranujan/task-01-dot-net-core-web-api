using AutoMapper;
using Backend.Dtos.Category;
using Backend.Dtos.Subcategory;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/subcategory")]
    [ApiController]
    public class SubcategoryController : ControllerBase
    {
        private readonly ISubcategoryRepository _subcategoryRepo;
        private readonly IMapper _mapper;
        public SubcategoryController(ISubcategoryRepository subcategoryRepo, IMapper mapper)
        {
            _subcategoryRepo = subcategoryRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var subcategoryModel = await _subcategoryRepo.GetAllAsync();
            var subcategoryDto = _mapper.Map<IEnumerable<SubcategoryDto>>(subcategoryModel);
            return Ok(subcategoryDto);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var subcategoryModel = await _subcategoryRepo.GetByIdAsync(id);
            if(subcategoryModel== null)
            {
                return NotFound();
            }
            var subcategoryDtos = _mapper.Map<SubcategoryDto>(subcategoryModel);
            return Ok(subcategoryDtos);

        }

        [HttpGet]
        [Route("getbycatgory/{id}")]
        public async Task<IActionResult> GetByCategoryId([FromRoute] int id)
        {
            var subcategories = await _subcategoryRepo.GetByCategoryIdAsync(id);
            if (subcategories == null)
            {
                return NotFound();
            }
            var subcategoryDtos = _mapper.Map<List<SubcategoryDto>>(subcategories);
            return Ok(subcategoryDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SubcategoryCreateDto subcategoryCreateDto)
        {
            var subcategoryModel = _mapper.Map<Subcategory>(subcategoryCreateDto);
            await _subcategoryRepo.CreateAsync(subcategoryModel);
            var subcategoryDto = _mapper.Map<SubcategoryDto>(subcategoryModel);

            return CreatedAtAction(nameof(GetById), new { id = subcategoryDto.SubcategoryId }, subcategoryDto);

        }

    


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SubCategoryUpdateDto subcategoryUpdateDto)
        {

            var existingSubcategory = await _subcategoryRepo.GetByIdAsync(id);
            if (existingSubcategory == null)
            {
                return NotFound();
            }


            _mapper.Map(subcategoryUpdateDto, existingSubcategory);

            await _subcategoryRepo.UpdateAsync(existingSubcategory);

            var updatedSubcategoryDto = _mapper.Map<SubcategoryDto>(existingSubcategory);
            return Ok(updatedSubcategoryDto);
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var subcategoryModel = await _subcategoryRepo.DeleteAsync(id);

            if (subcategoryModel == null)
            {
                return NotFound();
            }

            return NoContent();

        }

    }
}

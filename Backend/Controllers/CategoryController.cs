using AutoMapper;
using Backend.Dtos.Category;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{

    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepository categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var category = await _categoryRepo.GetAllAsync();
            var categorydtos = _mapper.Map<IEnumerable<CategoryDto>>(category);
            return Ok(categorydtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var category = await _categoryRepo.GetByIdAsync(id);

            if (category == null)
            {
                return NotFound(); 
            }
            var categoryDto = _mapper.Map<CategoryDto>(category);

            return Ok(categoryDto); 
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryCreateDto categoryCreateDto)
        {
            var categoryModel = _mapper.Map<Category>(categoryCreateDto);

            await _categoryRepo.CreateAsync(categoryModel);

            var categoryDto = _mapper.Map<CategoryDto>(categoryModel);

            return CreatedAtAction(nameof(GetById), new { id = categoryDto.CategoryId }, categoryDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoryUpdatedto categoryUpdateDto)
        {
           
            var existingCategory = await _categoryRepo.GetByIdAsync(id);
            if (existingCategory == null)
            {
                return NotFound(); 
            }

            
            _mapper.Map(categoryUpdateDto, existingCategory);

            await _categoryRepo.UpdateAsync(existingCategory);

            var updatedCategoryDto = _mapper.Map<CategoryDto>(existingCategory);
            return Ok(updatedCategoryDto);
        }



        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var categoryModel = await _categoryRepo.DeleteAsync(id);

            if (categoryModel == null)
            {
                return NotFound();
            }

            return NoContent();

        }


    }
}
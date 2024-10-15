using AutoMapper;
using Backend.Dtos.Size;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/size")] 
    [ApiController] 
    public class SizeController : ControllerBase
    {
        private readonly ISizeRepository _sizeRepo;
        private readonly IMapper _mapper;

        public SizeController(ISizeRepository sizeRepo, IMapper mapper)
        {
            _sizeRepo = sizeRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sizes = await _sizeRepo.GetAllAsync();
            var sizeDtos = _mapper.Map<IEnumerable<SizeDto>>(sizes);
            return Ok(sizeDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var size = await _sizeRepo.GetByIdAsync(id);

            if (size == null)
            {
                return NotFound();
            }

            var sizeDto = _mapper.Map<SizeDto>(size);
            return Ok(sizeDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SizeCreateDto sizeCreateDto)
        {
            var sizeModel = _mapper.Map<Size>(sizeCreateDto);
            await _sizeRepo.CreateAsync(sizeModel);
            var sizeDto = _mapper.Map<SizeDto>(sizeModel); 

            return CreatedAtAction(nameof(GetById), new { id = sizeDto.SizeId }, sizeDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SizeUpdateDto sizeUpdatedto)
        {
            var existingSize = await _sizeRepo.GetByIdAsync(id);
            if (existingSize == null)
            {
                return NotFound();
            }

            _mapper.Map(sizeUpdatedto, existingSize);
            await _sizeRepo.UpdateAsync(existingSize);

            var updatedSizeDto = _mapper.Map<SizeDto>(existingSize); // Corrected here
            return Ok(updatedSizeDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var sizeModel = await _sizeRepo.DeleteAsync(id);

            if (sizeModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

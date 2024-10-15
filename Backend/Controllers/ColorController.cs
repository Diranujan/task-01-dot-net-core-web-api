using AutoMapper;
using Backend.Dtos.Color;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/color")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IColorRepository _colorRepo;
        private readonly IMapper _mapper;

        public ColorController(IColorRepository colorRepo, IMapper mapper)
        {
            _colorRepo = colorRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var colors = await _colorRepo.GetAllAsync();
            var colorDtos = _mapper.Map<IEnumerable<ColorDto>>(colors);
            return Ok(colorDtos);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var color = await _colorRepo.GetByIdAsync(id);

            if (color == null)
            {
                return NotFound();
            }

            var colorDto = _mapper.Map<ColorDto>(color);
            return Ok(colorDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ColorCreateDto colorCreateDto)
        {
            var colorModel = _mapper.Map<Color>(colorCreateDto);
            await _colorRepo.CreateAsync(colorModel);
            var colorDto = _mapper.Map<ColorDto>(colorModel);

            return CreatedAtAction(nameof(GetById), new { id = colorDto.ColorId }, colorDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ColorUpdateDto colorUpdatedto)
        {
            var existingColor = await _colorRepo.GetByIdAsync(id);
            if (existingColor == null)
            {
                return NotFound();
            }

            _mapper.Map(colorUpdatedto, existingColor);
            await _colorRepo.UpdateAsync(existingColor);

            var updatedColorDto = _mapper.Map<ColorDto>(existingColor); 
            return Ok(updatedColorDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deletedColor = await _colorRepo.DeleteAsync(id);

            if (deletedColor == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

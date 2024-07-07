using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityApi.Data;
using UniversityApi.Dto;
using UniversityApi.Models;

namespace UniversityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MajorController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public MajorController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MajorDTO>>> GetMajors()
        {
            var majors = await _context.Majors.Include(m => m.College).ToListAsync();
            return Ok(_mapper.Map<List<MajorDTO>>(majors));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MajorDTO>> GetMajor(int id)
        {
            var major = await _context.Majors.Include(m => m.College).FirstOrDefaultAsync(m => m.MajorId == id);

            if (major == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<MajorDTO>(major));
        }

        [HttpPost]
        public async Task<ActionResult<MajorDTO>> PostMajor(MajorDTO majorDto)
        {
            var major = _mapper.Map<Major>(majorDto);
            _context.Majors.Add(major);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMajor), new { id = major.MajorId }, _mapper.Map<MajorDTO>(major));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMajor(int id, MajorDTO majorDto)
        {
            if (id != majorDto.MajorId)
            {
                return BadRequest();
            }

            var major = _mapper.Map<Major>(majorDto);
            _context.Entry(major).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Majors.Any(e => e.MajorId == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMajor(int id)
        {
            var major = await _context.Majors.Include(m => m.College).FirstOrDefaultAsync(m => m.MajorId == id);
            if (major == null)
            {
                return NotFound();
            }

            _context.Majors.Remove(major);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

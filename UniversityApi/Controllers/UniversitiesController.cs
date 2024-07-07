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
    public class UniversityController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UniversityController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UniversityDto>>> GetUniversities()
        {
            var universities = await _context.Universities.Include(u => u.Colleges).ToListAsync();
            return Ok(_mapper.Map<List<UniversityDto>>(universities));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UniversityDto>> GetUniversity(int id)
        {
            var university = await _context.Universities.Include(u => u.Colleges).FirstOrDefaultAsync(u => u.UniversityId == id);

            if (university == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UniversityDto>(university));
        }

        [HttpPost]
        public async Task<ActionResult<UniversityDto>> PostUniversity(UniversityDto universityDto)
        {
            var university = _mapper.Map<University>(universityDto);
            _context.Universities.Add(university);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUniversity), new { id = university.UniversityId }, _mapper.Map<UniversityDto>(university));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUniversity(int id, UniversityDto universityDto)
        {
            if (id != universityDto.UniversityId)
            {
                return BadRequest();
            }

            var university = _mapper.Map<University>(universityDto);
            _context.Entry(university).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Universities.Any(e => e.UniversityId == id))
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
        public async Task<IActionResult> DeleteUniversity(int id)
        {
            var university = await _context.Universities.Include(u => u.Colleges).FirstOrDefaultAsync(u => u.UniversityId == id);
            if (university == null)
            {
                return NotFound();
            }

            _context.Universities.Remove(university);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

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
    public class CollegeController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CollegeController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CollegeDto>>> GetColleges()
        {
            var colleges = await _context.Colleges.Include(c => c.University).ToListAsync();
            return Ok(_mapper.Map<List<CollegeDto>>(colleges));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CollegeDto>> GetCollege(int id)
        {
            var college = await _context.Colleges.Include(c => c.University).FirstOrDefaultAsync(c => c.CollegeId == id);

            if (college == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CollegeDto>(college));
        }

        [HttpPost]
        public async Task<ActionResult<CollegeDto>> PostCollege(CollegeDto collegeDto)
        {
            var college = _mapper.Map<College>(collegeDto);
            _context.Colleges.Add(college);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCollege), new { id = college.CollegeId }, _mapper.Map<CollegeDto>(college));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCollege(int id, CollegeDto collegeDto)
        {
            if (id != collegeDto.CollegeId)
            {
                return BadRequest();
            }

            var college = _mapper.Map<College>(collegeDto);
            _context.Entry(college).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Colleges.Any(e => e.CollegeId == id))
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
        public async Task<IActionResult> DeleteCollege(int id)
        {
            var college = await _context.Colleges.Include(c => c.University).FirstOrDefaultAsync(c => c.CollegeId == id);
            if (college == null)
            {
                return NotFound();
            }

            _context.Colleges.Remove(college);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}

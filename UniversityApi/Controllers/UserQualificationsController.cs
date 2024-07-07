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
    public class UserQualificationController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserQualificationController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserQualificationDTO>>> GetUserQualifications()
        {
            var qualifications = await _context.UserQualifications.ToListAsync();
            return Ok(_mapper.Map<List<UserQualificationDTO>>(qualifications));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserQualificationDTO>> GetUserQualification(int id)
        {
            var qualification = await _context.UserQualifications.FindAsync(id);

            if (qualification == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UserQualificationDTO>(qualification));
        }

        [HttpPost]
        public async Task<ActionResult<UserQualificationDTO>> PostUserQualification(UserQualificationDTO qualificationDto)
        {
            var qualification = _mapper.Map<UserQualification>(qualificationDto);
            _context.UserQualifications.Add(qualification);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserQualification), new { id = qualification.Id }, _mapper.Map<UserQualificationDTO>(qualification));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserQualification(int id, UserQualificationDTO qualificationDto)
        {
            if (id != qualificationDto.Id)
            {
                return BadRequest();
            }

            var qualification = _mapper.Map<UserQualification>(qualificationDto);
            _context.Entry(qualification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.UserQualifications.Any(e => e.Id == id))
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
        public async Task<IActionResult> DeleteUserQualification(int id)
        {
            var qualification = await _context.UserQualifications.FindAsync(id);
            if (qualification == null)
            {
                return NotFound();
            }

            _context.UserQualifications.Remove(qualification);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}

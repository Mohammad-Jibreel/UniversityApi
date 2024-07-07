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
    public class UserProfileController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserProfileController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserProfileDTO>>> GetUserProfiles()
        {
            var profiles = await _context.UserProfiles.Include(up => up.UserQualifications).ToListAsync();
            return Ok(_mapper.Map<List<UserProfileDTO>>(profiles));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserProfileDTO>> GetUserProfile(int id)
        {
            var profile = await _context.UserProfiles.Include(up => up.UserQualifications).Include(down=>down.User).FirstOrDefaultAsync(down => down.UserId == id);

            if (profile == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UserProfileDTO>(profile));
        }

        [HttpPost]
        public async Task<ActionResult<UserProfileDTO>> PostUserProfile(UserProfileDTO profileDto)
        {
            var profile = _mapper.Map<UserProfile>(profileDto);
            _context.UserProfiles.Add(profile);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserProfile), new { id = profile.Id }, _mapper.Map<UserProfileDTO>(profile));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserProfile(int id, UserProfileDTO profileDto)
        {
            if (id != profileDto.Id)
            {
                return BadRequest();
            }

            var profile = _mapper.Map<UserProfile>(profileDto);
            _context.Entry(profile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.UserProfiles.Any(e => e.Id == id))
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
        public async Task<IActionResult> DeleteUserProfile(int id)
        {
            var profile = await _context.UserProfiles.Include(up => up.UserQualifications).FirstOrDefaultAsync(up => up.Id == id);
            if (profile == null)
            {
                return NotFound();
            }

            _context.UserProfiles.Remove(profile);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
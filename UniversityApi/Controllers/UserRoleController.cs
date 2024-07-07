using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityApi.Data;
using UniversityApi.Dto;
using UniversityApi.Models;

namespace UniversityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserRoleController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRoleDTO>>> GetUserRoles()
        {
            var roles = await _context.UserRoles.ToListAsync();
            return _mapper.Map<List<UserRoleDTO>>(roles);

     
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserRoleDTO>> GetUserRole(int id)
        {
            var role = await _context.UserRoles.FindAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            return _mapper.Map<UserRoleDTO>(role);
        }

        [HttpPost]
        public async Task<ActionResult<UserRoleDTO>> PostUserRole(UserRoleDTO roleDto)
        {
            var role = _mapper.Map<UserRole>(roleDto);
            _context.UserRoles.Add(role);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserRole), new { id = role.UserRoleId }, _mapper.Map<UserRoleDTO>(role));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserRole(int id, UserRoleDTO roleDto)
        {
            if (id != roleDto.UserRoleId)
            {
                return BadRequest();
            }

            var role = _mapper.Map<UserRole>(roleDto);
            _context.Entry(role).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.UserRoles.Any(e => e.UserRoleId == id))
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
        public async Task<IActionResult> DeleteUserRole(int id)
        {
            var role = await _context.UserRoles.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            _context.UserRoles.Remove(role);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

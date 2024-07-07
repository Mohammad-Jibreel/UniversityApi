using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityApi.Data;
using UniversityApi.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace UniversityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        //    private readonly AppDbContext _dbContext;

        //    public RolesController(AppDbContext dbContext)
        //    {
        //        _dbContext = dbContext;
        //    }

        //    // Create
        //    [HttpPost]
        //    public async Task<IActionResult> CreateRole([FromBody] Role roleDto)
        //    {
        //        var role = new Role
        //        {
        //            RoleName = roleDto.RoleName
        //            // Users are not included to avoid circular references
        //        };

        //        _dbContext.Roles.Add(role);
        //        await _dbContext.SaveChangesAsync();

        //        // Return the created role as a DTO
        //        return CreatedAtAction(nameof(GetRoleById), new { id = role.RoleId }, new Role { RoleId = role.RoleId, RoleName = role.RoleName });
        //    }

        //    // Read
        //    [HttpGet]
        //    public async Task<IActionResult> GetRoles()
        //    {
        //        var roles = await _dbContext.Roles
        //            .Select(role => new Role
        //            {
        //                RoleId = role.RoleId,
        //                RoleName = role.RoleName
        //            })
        //            .ToListAsync();

        //        return Ok(roles);
        //    }

        //    [HttpGet("{id}")]
        //    public async Task<IActionResult> GetRoleById(int id)
        //    {
        //        var role = await _dbContext.Roles
        //            .Where(r => r.RoleId == id)
        //            .Select(r => new Role
        //            {
        //                RoleId = r.RoleId,
        //                RoleName = r.RoleName
        //            })
        //            .FirstOrDefaultAsync();

        //        if (role == null)
        //            return NotFound();

        //        return Ok(role);
        //    }

        //    // Update
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> UpdateRole(int id, [FromBody] Role roleDto)
        //    {
        //        if (id != roleDto.RoleId)
        //            return BadRequest();

        //        var role = await _dbContext.Roles.FindAsync(id);
        //        if (role == null)
        //            return NotFound();

        //        role.RoleName = roleDto.RoleName;
        //        // No need to update Users here

        //        _dbContext.Entry(role).State = EntityState.Modified;
        //        await _dbContext.SaveChangesAsync();

        //        return NoContent();
        //    }

        //    // Delete
        //    [HttpDelete("{id}")]
        //    public async Task<IActionResult> DeleteRole(int id)
        //    {
        //        var role = await _dbContext.Roles.FindAsync(id);
        //        if (role == null)
        //            return NotFound();

        //        _dbContext.Roles.Remove(role);
        //        await _dbContext.SaveChangesAsync();

        //        return NoContent();
        //    }
        //}
    }
}

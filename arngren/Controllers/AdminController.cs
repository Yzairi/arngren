using arngren.Commun.Model;
using arngren.Service;
using Microsoft.AspNetCore.Mvc;

namespace arngren.Controllers;

[ApiController]
[Route("[controller]")]
public class AdminController : ControllerBase
{
    private readonly AdminService _adminService;

    public AdminController(AdminService adminService)
    {
        _adminService = adminService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Admin>>> GetAdmins()
    {
        return await _adminService.GetAdmins();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Admin>> GetAdmin(int id)
    {
        var admin = await _adminService.GetAdmin(id);

        if (admin == null)
        {
            return NotFound();
        }

        return admin;
    }

    [HttpPost]
    public async Task<ActionResult<Admin>> PostAdmin(Admin admin)
    {
        await _adminService.AddAdmin(admin);

        return CreatedAtAction(nameof(GetAdmin), new { id = admin.Id }, admin);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAdmin(int id, Admin admin)
    {
        if (id != admin.Id)
        {
            return BadRequest();
        }

        await _adminService.UpdateAdmin(id, admin);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAdmin(int id)
    {
        var deleted = await _adminService.DeleteAdmin(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}

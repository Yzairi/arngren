using arngren.Commun.Model;
using arngren.Data;
using Microsoft.EntityFrameworkCore;

namespace arngren.Service;

public class AdminService 
{
    private readonly ArngrenContext _context;

    public AdminService(ArngrenContext context)
    {
        _context = context;
    }

    public async Task<List<Admin>> GetAdmins()
    {
        return await _context.Admins.ToListAsync();
    }

    public async Task<Admin> GetAdmin(int id)
    {
        return await _context.Admins.FindAsync(id);
    }

    public async Task<Admin> AddAdmin(Admin admin)
    {
        _context.Admins.Add(admin);
        await _context.SaveChangesAsync();
        return admin;
    }

    public async Task<Admin> UpdateAdmin(int id, Admin admin)
    {
        _context.Entry(admin).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return admin;
    }

    public async Task<bool> DeleteAdmin(int id)
    {
        var admin = await _context.Admins.FindAsync(id);
        if (admin == null)
        {
            return false;
        }

        _context.Admins.Remove(admin);
        await _context.SaveChangesAsync();
        return true;
    }
}
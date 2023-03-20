using arngren.Commun.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace arngren.Data;

public class ArngrenContext : DbContext
{   
    public ArngrenContext(DbContextOptions<ArngrenContext> options) : base(options)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ArngrenDB;Trusted_Connection=True;");
        }
    }

    public DbSet<Article> Articles { get; set; }
    public DbSet<Admin> Admins { get; set; }
}
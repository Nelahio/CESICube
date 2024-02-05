using EnchereService.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnchereService.Data;

public class EnchereDbContext : DbContext
{
    public EnchereDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Enchere> Encheres { get; set; }
}

using Microsoft.EntityFrameworkCore;

namespace Phones.Entities;

public class PhonesDbContext : DbContext
{
    private string _connectionString =
            "Server=.\\SQLEXPRESS;Database=PhonesDb;Trusted_Connection=True;";
    public DbSet<Phone> Phones { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }
}

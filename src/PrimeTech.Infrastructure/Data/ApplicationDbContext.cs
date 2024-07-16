using Microsoft.EntityFrameworkCore;
using PrimeTech.Interview.Business.Domain.Entities;

namespace PrimeTech.Interview.Business.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Company> Companies { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var defaultConnection = "Server = localhost,1433; Database = PrimeTech; User Id = sa; Password = 1qazZAQ!; Encrypt=false;";
            optionsBuilder.UseSqlServer(defaultConnection);
        }

    }
}

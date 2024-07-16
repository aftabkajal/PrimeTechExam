using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PrimeTech.Interview.Business.Infrastructure.Data;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var defaultConnection = "Server = localhost,1433; Database = PrimeTech; User Id = sa; Password = 1qazZAQ!; Encrypt=false;";
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer(defaultConnection);

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}

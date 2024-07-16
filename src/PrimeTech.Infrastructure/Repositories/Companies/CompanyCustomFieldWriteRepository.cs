using Microsoft.EntityFrameworkCore;
using PrimeTech.Interview.Business.Domain.AggregatesModel.Companies;
using PrimeTech.Interview.Business.Domain.Entities;
using PrimeTech.Interview.Business.Infrastructure.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeTech.Interview.Business.Infrastructure.Repositories.Companies
{
    public class CompanyCustomFieldWriteRepository : WriteRepository<CompanyCustomField>, ICompanyCustomFieldWriteRepository
    {
        public CompanyCustomFieldWriteRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task DeleteCompanyCustomFieldsByCompanyIdAsync(int companyId)
        {
            await _dbSet.Where(a => a.CompanyID == companyId).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
        }
    }
}

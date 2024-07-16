using Microsoft.EntityFrameworkCore;
using PrimeTech.Interview.Business.Domain.AggregatesModel.Companies;
using PrimeTech.Interview.Business.Domain.Entities;
using PrimeTech.Interview.Business.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeTech.Interview.Business.Infrastructure.Repositories.Companies;

public class CompanyCustomFieldReadRepository : ReadRepository<CompanyCustomField>, ICompanyCustomFieldReadRepository
{
    public CompanyCustomFieldReadRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<List<CompanyCustomField>> GetCompanyCustomFieldsByCompanyIdAsync(int companyId)
    {
        return await _dbSet.Where(field => field.CompanyID == companyId).ToListAsync();
    }
}


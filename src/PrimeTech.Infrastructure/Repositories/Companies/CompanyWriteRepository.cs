using PrimeTech.Interview.Business.Domain.AggregatesModel.Companies;
using PrimeTech.Interview.Business.Infrastructure.Data;
using PrimeTech.Interview.Business.Domain.Entities;

namespace PrimeTech.Interview.Business.Infrastructure.Repositories.Companies;

public class CompanyWriteRepository : WriteRepository<Company>, ICompanyWriteRepository
{
    public CompanyWriteRepository(ApplicationDbContext context) : base(context)
    {
    }
}


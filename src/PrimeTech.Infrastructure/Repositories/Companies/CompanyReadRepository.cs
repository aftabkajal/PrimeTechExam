using PrimeTech.Interview.Business.Domain.AggregatesModel.Companies;
using PrimeTech.Interview.Business.Domain.Entities;
using PrimeTech.Interview.Business.Infrastructure.Data;

namespace PrimeTech.Interview.Business.Infrastructure.Repositories.Companies;

public class CompanyReadRepository : ReadRepository<Company>, ICompanyReadRepository
{
    public CompanyReadRepository(ApplicationDbContext context) : base(context)
    {
    }
}


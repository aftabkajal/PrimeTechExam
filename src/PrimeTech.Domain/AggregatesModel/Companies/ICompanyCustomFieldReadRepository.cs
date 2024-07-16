using PrimeTech.Interview.Business.Domain.Entities;
using PrimeTech.Interview.Business.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeTech.Interview.Business.Domain.AggregatesModel.Companies
{
    public interface ICompanyCustomFieldReadRepository : IReadRepository<CompanyCustomField>
    {
        Task<List<CompanyCustomField>> GetCompanyCustomFieldsByCompanyIdAsync(int companyId);
    }
}

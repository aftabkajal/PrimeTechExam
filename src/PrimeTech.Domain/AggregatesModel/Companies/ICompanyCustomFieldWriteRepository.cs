using PrimeTech.Interview.Business.Domain.Entities;
using PrimeTech.Interview.Business.Domain.Interfaces.Repositories;
using System.Threading.Tasks;

namespace PrimeTech.Interview.Business.Domain.AggregatesModel.Companies
{
    public interface ICompanyCustomFieldWriteRepository : IWriteRepository<CompanyCustomField>
    {
        Task DeleteCompanyCustomFieldsByCompanyIdAsync(int companyId);
    }
}

using PrimeTech.Interview.Business.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeTech.Interview.Business.Application.Interfaces
{
    public interface ICompanyCustomFieldService
    {
        Task AddCustomFieldAsync(CompanyCustomField company);

        Task DeleteCustomFieldAsync(int id);

        Task<IEnumerable<CompanyCustomField>> GetAllCustomFieldaByCompanyIdAsync(int companyId);
    }
}

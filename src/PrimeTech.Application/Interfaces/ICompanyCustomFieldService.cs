using PrimeTech.Interview.Business.Domain.Dtos;
using PrimeTech.Interview.Business.Domain.Entities;
using System.Threading.Tasks;

namespace PrimeTech.Interview.Business.Application.Interfaces
{
    public interface ICompanyCustomFieldService
    {
        Task AddCustomFieldAsync(CompanyCustomField company);

        Task DeleteCustomFieldsAsync(int companyId);

        Task<CompanyCustomFieldDtos> GetAllCustomFieldaByCompanyIdAsync(int companyId);
    }
}

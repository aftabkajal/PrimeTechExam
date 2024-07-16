using PrimeTech.Interview.Business.Domain.Dtos;
using PrimeTech.Interview.Business.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeTech.Interview.Business.Application.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync();
        Task<CompanyDto> GetCompanyByIdAsync(int id);
        Task AddCompanyAsync(Company company);
        Task UpdateCompanyAsync(Company company);
        Task DeleteCompanyAsync(int id);
    }
}

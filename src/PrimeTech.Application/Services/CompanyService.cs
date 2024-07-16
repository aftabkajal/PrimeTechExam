using PrimeTech.Interview.Business.Application.Interfaces;
using PrimeTech.Interview.Business.Domain.AggregatesModel.Companies;
using PrimeTech.Interview.Business.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeTech.Interview.Business.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyReadRepository _companyReadRepository;
        private readonly ICompanyWriteRepository _companyWriteRepository;
        public CompanyService(
            ICompanyReadRepository companyReadRepository,
            ICompanyWriteRepository companyWriteRepository)
        {
            _companyReadRepository = companyReadRepository ?? throw new ArgumentNullException(nameof(companyReadRepository));
            _companyWriteRepository = companyWriteRepository ?? throw new ArgumentNullException(nameof(companyWriteRepository));
        }
        public async Task AddCompanyAsync(Company company)
        {
          await _companyWriteRepository.AddAsync(company);
        }

        public async Task DeleteCompanyAsync(int id)
        {
            await _companyWriteRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
            return await _companyReadRepository.GetAllAsync();
        }

        public async Task<Company> GetCompanyByIdAsync(int id)
        {
           return await _companyReadRepository.GetByIdAsync(id);
        }

        public async Task UpdateCompanyAsync(Company company)
        {
            await _companyWriteRepository.UpdateAsync(company);
        }
    }
}

using PrimeTech.Interview.Business.Application.Interfaces;
using PrimeTech.Interview.Business.Domain.AggregatesModel.Companies;
using PrimeTech.Interview.Business.Domain.Dtos;
using PrimeTech.Interview.Business.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync()
        {
            var companies = await _companyReadRepository.GetAllAsync();
            return companies.Select(x => new CompanyDto { Id = x.Id, Name = x.Name, Address = x.Address }).ToList();
        }

        public async Task<CompanyDto> GetCompanyByIdAsync(int id)
        {
            var company = await _companyReadRepository.GetByIdAsync(id);
            if (company == null) return new CompanyDto();

            return new CompanyDto { Id = company.Id, Address = company.Address, Name = company.Name };
        }

        public async Task UpdateCompanyAsync(Company company)
        {
            await _companyWriteRepository.UpdateAsync(company);
        }
    }
}

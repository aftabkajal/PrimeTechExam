using PrimeTech.Interview.Business.Application.Interfaces;
using PrimeTech.Interview.Business.Domain.AggregatesModel.Companies;
using PrimeTech.Interview.Business.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeTech.Interview.Business.Application.Services
{
    public class CompanyCustomFieldService : ICompanyCustomFieldService
    {
        private readonly ICompanyCustomFieldReadRepository _readRepository;
        private readonly ICompanyCustomFieldWriteRepository _writeRepository;
        public CompanyCustomFieldService(
            ICompanyCustomFieldReadRepository readRepository,
            ICompanyCustomFieldWriteRepository writeRepository)
        {
            _readRepository = readRepository ?? throw new ArgumentNullException(nameof(readRepository));
            _writeRepository = writeRepository ?? throw new ArgumentNullException(nameof(writeRepository));
        }
        public async Task AddCustomFieldAsync(CompanyCustomField company)
        {
            await _writeRepository.AddAsync(company);
        }

        public async Task DeleteCustomFieldAsync(int id)
        {
            await _writeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CompanyCustomField>> GetAllCustomFieldaByCompanyIdAsync(int companyId)
        {
            return await _readRepository.GetCompanyCustomFieldsByCompanyIdAsync(companyId);
        }
    }
}

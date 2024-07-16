using PrimeTech.Interview.Business.Application.Interfaces;
using PrimeTech.Interview.Business.Domain.AggregatesModel.Companies;
using PrimeTech.Interview.Business.Domain.Dtos;
using PrimeTech.Interview.Business.Domain.Entities;
using System;
using System.Linq;
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

        public async Task DeleteCustomFieldsAsync(int companyId)
        {
            await _writeRepository.DeleteCompanyCustomFieldsByCompanyIdAsync(companyId);
        }

        public async Task<CompanyCustomFieldDtos> GetAllCustomFieldaByCompanyIdAsync(int companyId)
        {
            var fields = await _readRepository.GetCompanyCustomFieldsByCompanyIdAsync(companyId);
            var companyCustomFieldDto = new CompanyCustomFieldDtos { CompanyID = companyId };
            var customFields = fields.Select(a => new CompanyCustomFieldDto { FieldName = a.FieldName, FieldValue = a.FieldValue, Id = a.Id }).ToList();
            companyCustomFieldDto.CustomFields = customFields ?? [];
            return companyCustomFieldDto;
        }
    }
}

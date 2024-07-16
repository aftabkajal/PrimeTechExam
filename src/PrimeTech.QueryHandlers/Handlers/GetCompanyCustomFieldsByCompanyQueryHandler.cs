using PrimeTech.Interview.Business.Application.Interfaces;
using PrimeTech.Interview.Business.Domain.Common;
using PrimeTech.Interview.Business.Queries.Queries;
using System;
using System.Threading.Tasks;

namespace PrimeTech.Interview.Business.QueryHandlers.Handlers
{
    public class GetCompanyCustomFieldsByCompanyQueryHandler : IQueryHandler<GetCompanyCustomFieldsByCompanyQuery, StringResult>
    {
        private readonly ICompanyCustomFieldService _companyCustomFieldService;
        public GetCompanyCustomFieldsByCompanyQueryHandler(
            ICompanyCustomFieldService companyCustomFieldService)
        {
            _companyCustomFieldService = companyCustomFieldService ?? throw new ArgumentNullException(nameof(companyCustomFieldService));
        }
        public async Task<StringResult> HandleAsync(GetCompanyCustomFieldsByCompanyQuery query)
        {
            var queryResponse = await _companyCustomFieldService.GetAllCustomFieldaByCompanyIdAsync(query.CompanyID);
            var result = new StringResult(queryResponse);
            return result;
        }
    }
}

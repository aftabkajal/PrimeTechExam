using PrimeTech.Interview.Business.Application.Interfaces;
using PrimeTech.Interview.Business.Domain.Common;
using PrimeTech.Interview.Business.Queries.Queries;
using System;
using System.Threading.Tasks;

namespace PrimeTech.Interview.Business.QueryHandlers.Handlers;

public class GetAllCompaniesQueryHandler : IQueryHandler<GetAllCompaniesQuery, StringResult>
{
    private readonly ICompanyService _companyService;
    public GetAllCompaniesQueryHandler(
        ICompanyService companyService)
    {
        _companyService = companyService ?? throw new ArgumentNullException(nameof(companyService));
    }
    public async Task<StringResult> HandleAsync(GetAllCompaniesQuery query)
    {
        var companies = await _companyService.GetAllCompaniesAsync();
        var result = new StringResult(companies);
        return result;
    }
}


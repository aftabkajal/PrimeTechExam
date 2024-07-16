using PrimeTech.Interview.Business.Application.Interfaces;
using PrimeTech.Interview.Business.Domain.Common;
using PrimeTech.Interview.Business.Queries.Queries;
using System;
using System.Threading.Tasks;

namespace PrimeTech.Interview.Business.QueryHandlers.Handlers;

public class GetCompanyQueryHandler : IQueryHandler<GetCompanyQuery, StringResult>
{
    private readonly ICompanyService _companyService;
    public GetCompanyQueryHandler(
        ICompanyService companyService)
    {
        _companyService = companyService ?? throw new ArgumentNullException(nameof(companyService));
    }
    public async Task<StringResult> HandleAsync(GetCompanyQuery query)
    {
        var queryResponse = await _companyService.GetCompanyByIdAsync(query.CompanyID);
        var result = new StringResult(queryResponse);
        return result;
    }
}


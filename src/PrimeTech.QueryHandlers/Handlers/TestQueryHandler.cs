using PrimeTech.Interview.Business.Domain.Common;
using PrimeTech.Interview.Business.Queries.Queries;
using System.Threading.Tasks;

namespace PrimeTech.Interview.Business.QueryHandlers.Handlers;

public class TestQueryHandler : IQueryHandler<TestQuery, StringResult>
{
    public TestQueryHandler()
    {

    }

    public async Task<StringResult> HandleAsync(TestQuery query)
    {
        var stringResult = new StringResult(new object());
        return await Task.FromResult(stringResult);
    }
}


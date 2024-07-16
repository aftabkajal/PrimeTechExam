using PrimeTech.Interview.Business.Domain.Dispatchers;
using PrimeTech.Interview.Business.Infrastructure.Common;
using System;
using System.Threading.Tasks;

namespace PrimeTech.Interview.Business.Infrastructure.Dispatcher;

public class QueryDispatcher
        : IQueryDispatcher
{
    private readonly QueryHandler _queryHandler;

    public QueryDispatcher(QueryHandler queryHandler)
    {
        _queryHandler = queryHandler ?? throw new ArgumentNullException(nameof(queryHandler));
    }

    public async Task<TResponse> DispatchAsync<TQuery, TResponse>(TQuery query)
    {
        var result = await _queryHandler.SubmitAsync<TQuery, TResponse>(query);
        return result;
    }
}

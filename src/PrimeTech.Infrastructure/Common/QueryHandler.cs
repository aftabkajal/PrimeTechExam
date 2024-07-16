using PrimeTech.Interview.Business.Domain.Common;
using System;
using System.Threading.Tasks;

namespace PrimeTech.Interview.Business.Infrastructure.Common;

public class QueryHandler
{
    private readonly IServiceProvider serviceProvider;
    public QueryHandler(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public Task<TQueryResponse> SubmitAsync<TQuery, TQueryResponse>(TQuery query)
    {
        var queryHandler = serviceProvider.GetService(typeof(IQueryHandler<TQuery, TQueryResponse>)) as IQueryHandler<TQuery, TQueryResponse>;

        return queryHandler.HandleAsync(query);
    }
}


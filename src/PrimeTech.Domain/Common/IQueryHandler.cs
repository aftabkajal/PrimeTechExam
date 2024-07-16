using System.Threading.Tasks;

namespace PrimeTech.Interview.Business.Domain.Common;

public interface IQueryHandler<TQuery, TQueryResponse>
{
    Task<TQueryResponse> HandleAsync(TQuery query);
}

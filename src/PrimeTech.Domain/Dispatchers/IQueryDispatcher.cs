using System.Threading.Tasks;

namespace PrimeTech.Interview.Business.Domain.Dispatchers;

public interface IQueryDispatcher
{
    Task<TResponse> DispatchAsync<TQuery, TResponse>(TQuery query);
}

using System.Threading.Tasks;

namespace PrimeTech.Interview.Business.Domain.Dispatchers;

public interface ICommandDispatcher
{
    Task DispatchAsync<TCommand>(
            TCommand command);
    Task<TResponse> DispatchAsync<TCommand, TResponse>(
            TCommand command);

    void ValidateCommand<TCommand>(
            TCommand command);
}

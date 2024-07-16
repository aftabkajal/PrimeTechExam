using System.Threading.Tasks;

namespace PrimeTech.Interview.Business.Domain.Common;

public interface ICommandHandler<TCommand, TResponse>
{
    Task<TResponse> HandleAsync(TCommand command);
}


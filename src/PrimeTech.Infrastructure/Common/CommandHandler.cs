using PrimeTech.Interview.Business.Domain.Common;
using System;
using System.Threading.Tasks;

namespace PrimeTech.Interview.Business.Infrastructure.Common;

public class CommandHandler
{
    private readonly IServiceProvider serviceProvider;
    public CommandHandler(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public Task<TResponse> SubmitAsync<TCommand, TResponse>(TCommand command)
    {
        var commandHandler = serviceProvider.GetService(typeof(ICommandHandler<TCommand, TResponse>)) as ICommandHandler<TCommand, TResponse>;

        return commandHandler.HandleAsync(command);
    }
}


using Microsoft.Extensions.DependencyInjection;
using PrimeTech.Interview.Business.Domain.Common;
using PrimeTech.Interview.Business.Infrastructure.Common;
using System;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using PrimeTech.Interview.Business.Domain.Dispatchers;

namespace PrimeTech.Interview.Business.Infrastructure.Dispatcher
{
    public class CommandDispatcher
            : ICommandDispatcher
    {
        private readonly IServiceProvider _services;
        private readonly CommandHandler _commandHandler;

        public CommandDispatcher(
            IServiceProvider services,
            CommandHandler commandHandler)
        {
            _services = services;
            _commandHandler = commandHandler;
        }

        public async Task DispatchAsync<TCommand>(
            TCommand command)
        {
            ValidateCommand(command);

            await _commandHandler
                .SubmitAsync<TCommand, CommandResponse>(
                    command);
        }

        /// <inheritdoc />
        public async Task<TResponse> DispatchAsync<TCommand, TResponse>(
            TCommand command)
        {
            ValidateCommand(command);
            return await _commandHandler
                .SubmitAsync<TCommand, TResponse>(command);
        }

        public void ValidateCommand<TCommand>(
            TCommand command)
        {
            var validators = _services.GetServices<IValidator<TCommand>>();

            var failures = validators
                .Select(v => v.Validate(command))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (failures.Any())
            {
                throw new FluentValidation.ValidationException(failures);
            }
        }

    }
}

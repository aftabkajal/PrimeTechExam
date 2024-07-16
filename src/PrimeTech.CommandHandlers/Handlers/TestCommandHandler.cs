using PrimeTech.Interview.Business.Commands.Commands;
using PrimeTech.Interview.Business.Domain.Common;
using System;
using System.Threading.Tasks;

namespace PrimeTech.Interview.Business.CommandHandlers.Handlers
{
    public class TestCommandHandler : ICommandHandler<TestCommand, CommandResponse>
    {
        private readonly IPrimeTechLogger<TestCommandHandler> _logger;
        public TestCommandHandler(
            IPrimeTechLogger<TestCommandHandler> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<CommandResponse> HandleAsync(TestCommand command)
        {
            _logger.LogInformation("Inside of TestCommandHandler.HandleAsync");
            return new CommandResponse();
        }
    }
}

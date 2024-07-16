using PrimeTech.Interview.Business.Application.Interfaces;
using PrimeTech.Interview.Business.Commands.Commands;
using PrimeTech.Interview.Business.Domain.Common;
using System.Threading.Tasks;

namespace PrimeTech.Interview.Business.CommandHandlers.Handlers
{
    public class DeleteCompanyCommandHandler : ICommandHandler<DeleteCompanyCommand, CommandResponse>
    {
        private readonly IPrimeTechLogger<DeleteCompanyCommandHandler> _logger;
        private readonly ICompanyService _companyService;
        public DeleteCompanyCommandHandler(
            IPrimeTechLogger<DeleteCompanyCommandHandler> logger,
            ICompanyService companyService)
        {
            _logger = logger;
            _companyService = companyService;
        }
        public async Task<CommandResponse> HandleAsync(DeleteCompanyCommand command)
        {
            await _companyService.DeleteCompanyAsync(command.CompanyID);
            return new CommandResponse();
        }
    }
}

using PrimeTech.Interview.Business.Application.Interfaces;
using PrimeTech.Interview.Business.Commands.Commands;
using PrimeTech.Interview.Business.Domain.Common;
using PrimeTech.Interview.Business.Domain.Entities;
using System.Threading.Tasks;

namespace PrimeTech.Interview.Business.CommandHandlers.Handlers
{
    public class CreateCompanyCommandHandler : ICommandHandler<CreateCompanyCommand, CommandResponse>
    {
        private readonly IPrimeTechLogger<CreateCompanyCommandHandler> _logger;
        private readonly ICompanyService _companyService;
        public CreateCompanyCommandHandler(
            IPrimeTechLogger<CreateCompanyCommandHandler> logger,
            ICompanyService companyService)
        {
            _logger = logger;
            _companyService = companyService;
        }
        public async Task<CommandResponse> HandleAsync(CreateCompanyCommand command)
        {
            var company = new Company()
            {
                Name = command.Name,
                Address = command.Address,
            };

            await _companyService.AddCompanyAsync(company);
            return new CommandResponse();
        }
    }
}

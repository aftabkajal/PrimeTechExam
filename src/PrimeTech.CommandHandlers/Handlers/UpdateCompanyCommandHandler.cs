using PrimeTech.Interview.Business.Application.Interfaces;
using PrimeTech.Interview.Business.Commands.Commands;
using PrimeTech.Interview.Business.Domain.Common;
using PrimeTech.Interview.Business.Domain.Entities;
using System.Threading.Tasks;

namespace PrimeTech.Interview.Business.CommandHandlers.Handlers
{
    public class UpdateCompanyCommandHandler : ICommandHandler<UpdateCompanyCommand, CommandResponse>
    {
        private readonly IPrimeTechLogger<UpdateCompanyCommandHandler> _logger;
        private readonly ICompanyService _companyService;
        public UpdateCompanyCommandHandler(
            IPrimeTechLogger<UpdateCompanyCommandHandler> logger,
            ICompanyService companyService)
        {
            _logger = logger;
            _companyService = companyService;
        }
        public async Task<CommandResponse> HandleAsync(UpdateCompanyCommand command)
        {
            var company = new Company()
            {
                Id = command.CompanyID,
                Name = command.Name,
                Address = command.Address,
            };

            await _companyService.UpdateCompanyAsync(company);
            return new CommandResponse();
        }
    }
}

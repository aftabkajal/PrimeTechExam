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
        private readonly ICompanyCustomFieldService _companyCustomFieldService;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCompanyCommandHandler(
            IPrimeTechLogger<DeleteCompanyCommandHandler> logger,
            ICompanyService companyService,
            ICompanyCustomFieldService companyCustomFieldService,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _companyService = companyService;
            _companyCustomFieldService = companyCustomFieldService;
            _unitOfWork = unitOfWork;

        }
        public async Task<CommandResponse> HandleAsync(DeleteCompanyCommand command)
        {
            await _companyService.DeleteCompanyAsync(command.CompanyID);
            await _companyCustomFieldService.DeleteCustomFieldsAsync(command.CompanyID);
            await _unitOfWork.CompleteAsync();
            return new CommandResponse();
        }
    }
}

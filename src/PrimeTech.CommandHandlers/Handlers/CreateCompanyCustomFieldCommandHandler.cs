using PrimeTech.Interview.Business.Application.Interfaces;
using PrimeTech.Interview.Business.Commands.Commands;
using PrimeTech.Interview.Business.Domain.Common;
using PrimeTech.Interview.Business.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace PrimeTech.Interview.Business.CommandHandlers.Handlers
{
    public class CreateCompanyCustomFieldCommandHandler : ICommandHandler<CreateCompanyCustomFieldCommand, CommandResponse>
    {
        private readonly IPrimeTechLogger<CreateCompanyCustomFieldCommandHandler> _logger;
        private readonly ICompanyCustomFieldService _companyService;
        public CreateCompanyCustomFieldCommandHandler(
            IPrimeTechLogger<CreateCompanyCustomFieldCommandHandler> logger,
            ICompanyCustomFieldService companyService)
        {
            _logger = logger;
            _companyService = companyService;
        }
        public async Task<CommandResponse> HandleAsync(CreateCompanyCustomFieldCommand command)
        {
            var company = new CompanyCustomField()
            {
                CompanyID = command.CompanyID,
                FieldName = command.FieldName,
                FieldValue = command.FieldValue,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _companyService.AddCustomFieldAsync(company);
            return new CommandResponse();
        }
    }
}

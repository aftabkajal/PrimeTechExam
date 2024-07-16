using FluentValidation;
using PrimeTech.Interview.Business.Commands.Commands;

namespace PrimeTech.Interview.Business.WebService.Validators;

public class DeleteCompanyCommandValidator : AbstractValidator<DeleteCompanyCommand>
{
    public DeleteCompanyCommandValidator()
    {
        RuleFor(a => a.CompanyID)
            .GreaterThan(0).WithMessage("ID should be valid");
    }
}


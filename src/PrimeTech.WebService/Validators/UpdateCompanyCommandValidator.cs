using FluentValidation;
using PrimeTech.Interview.Business.Commands.Commands;

namespace PrimeTech.Interview.Business.WebService.Validators;

public class UpdateCompanyCommandValidator : AbstractValidator<UpdateCompanyCommand>
{
    public UpdateCompanyCommandValidator()
    {
        RuleFor(a => a.CompanyID)
            .GreaterThan(0).WithMessage("ID should be valid");

        RuleFor(a => a.Name)
            .NotEmpty().NotEmpty().WithMessage("Name should not be null or empty");

        RuleFor(a => a.Address)
            .NotEmpty().NotEmpty().WithMessage("Address should not be null or empty");
    }
}


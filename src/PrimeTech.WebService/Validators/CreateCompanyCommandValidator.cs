using FluentValidation;
using PrimeTech.Interview.Business.Commands.Commands;

namespace PrimeTech.Interview.Business.WebService.Validators;

public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
{
    public CreateCompanyCommandValidator()
    {
        RuleFor(a => a.Name)
            .NotEmpty().NotEmpty().WithMessage("Name should not be null or empty");

        RuleFor(a => a.Address)
            .NotEmpty().NotEmpty().WithMessage("Address should not be null or empty");
    }
}


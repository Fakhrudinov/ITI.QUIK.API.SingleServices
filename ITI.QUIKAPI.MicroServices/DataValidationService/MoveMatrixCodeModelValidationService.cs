using DataAbstraction.Models;
using FluentValidation;

namespace DataValidationService
{
    internal class MoveMatrixCodeModelValidationService : AbstractValidator<MoveMatrixCodeModel>
    {
        public MoveMatrixCodeModelValidationService()
        {
            RuleFor(x => x.ClientCode)
                .Matches("^B[PC][0-9]{4,6}-(MS|MO|FX|RS|CD)-[0-9]{2}$")
                    .WithMessage("{PropertyName} '{PropertyValue}' is not in format 'BP12345-XX-01'. Accept only MS|MO|FX|RS|CD portfolio")
                    .WithErrorCode("PP310");
            RuleFor(x => x.FromTemplate)
                .Length(3, 12)
                    .WithMessage("{PropertyName} '{PropertyValue}' must be minimum 3 and maximum 12 symbols lenght")
                    .WithErrorCode("PP311")
                .Matches("^([A-Za-z0-9_]+){3,12}$")
                    .WithMessage("{PropertyName} '{PropertyValue}' must contain only 'AZ az 09 and _'. No spaces")
                    .WithErrorCode("PP312");
            RuleFor(x => x.ToTemplate)
                .Length(3, 12)
                    .WithMessage("{PropertyName} '{PropertyValue}' must be minimum 3 and maximum 12 symbols lenght")
                    .WithErrorCode("PP313")
                .Matches("^([A-Za-z0-9_]+)$")
                    .WithMessage("{PropertyName} '{PropertyValue}' must contain only 'AZ az 09 and _'. No spaces")
                    .WithErrorCode("PP314");
        }
    }
}

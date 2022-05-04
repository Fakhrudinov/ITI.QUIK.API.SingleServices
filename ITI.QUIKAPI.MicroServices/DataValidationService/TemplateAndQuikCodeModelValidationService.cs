using DataAbstraction.Models;
using FluentValidation;

namespace DataValidationService
{
    public class TemplateAndQuikCodeModelValidationService : AbstractValidator<TemplateAndQuikCodeModel>
    {
        public TemplateAndQuikCodeModelValidationService()
        {
            RuleFor(x => x.ClientCode)
                .Matches("^B[PC][0-9]{4,6}\\/[D]{0,1}[0-9]{2}$")
                    .WithMessage("{PropertyName} '{PropertyValue}' is not in format 'BP12345/01' or 'BP12345/D01'")
                    .WithErrorCode("PP400");
            RuleFor(x => x.Template)
                .Length(3, 12)
                    .WithMessage("{PropertyName} '{PropertyValue}' must be minimum 3 and maximum 12 symbols lenght")
                    .WithErrorCode("PP401")
                .Matches("^([A-Za-z0-9_]+)$")
                    .WithMessage("{PropertyName} '{PropertyValue}' must contain only 'AZ az 09 and _'. No spaces")
                    .WithErrorCode("PP402");
        }
    }
}

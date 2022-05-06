using DataAbstraction.Models;
using FluentValidation;

namespace DataValidationService
{
    public class TemplateAndMatrixCodeModelValidationService : AbstractValidator<TemplateAndMatrixCodeModel>
    {
        public TemplateAndMatrixCodeModelValidationService()
        {
            RuleFor(x => x.ClientCode)
                .Matches("^B[PC][0-9]{4,6}-(MS|MO|CD|FX|RS)-[0-9]{2}$")
                    .WithMessage("{PropertyName} '{PropertyValue}' is not in format 'BP12345-XX-01'. Accept only MS|MO|CD|FX|RS portfolio")
                    .WithErrorCode("PP500");

            RuleFor(x => x.Template)
                .Length(3, 12)
                    .WithMessage("{PropertyName} '{PropertyValue}' must be minimum 3 and maximum 12 symbols lenght")
                    .WithErrorCode("PP501")
                .Matches("^([A-Za-z0-9_]+)$")
                    .WithMessage("{PropertyName} '{PropertyValue}' must contain only 'AZ az 09 and _'. No spaces")
                    .WithErrorCode("PP502");
        }
    }
}

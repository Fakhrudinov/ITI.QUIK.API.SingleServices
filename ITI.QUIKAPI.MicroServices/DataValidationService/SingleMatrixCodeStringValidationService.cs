using FluentValidation;

namespace DataValidationService
{
    public class SingleMatrixCodeStringValidationService : AbstractValidator<string>
    {
        public SingleMatrixCodeStringValidationService()
        {
            RuleFor(x => x)
                .Matches("^B[PC][0-9]{4,6}-(MS|MO|FX|RS)-[0-9]{2}$")
                    .WithMessage("{PropertyName} '{PropertyValue}' is not in format 'BP12345-XX-01'. Accept only MS|MO|FX|RS portfolio")
                    .WithErrorCode("PP700");
        }
    }
}

using DataAbstraction.Models;
using FluentValidation;


namespace DataValidationService
{
    public class MoveQuikCodeModelValidationService : AbstractValidator<MoveQuikCodeModel>
    {
        public MoveQuikCodeModelValidationService()
        {
            RuleFor(x => x.ClientCode)
                .Matches("^B[PC][0-9]{4,6}\\/[D]{0,1}[0-9]{2}$")
                    .WithMessage("{PropertyName} '{PropertyValue}' is not in format 'BP12345/01' or 'BP12345/D01'")
                    .WithErrorCode("PP300");
            RuleFor(x => x.FromTemplate)
                .Length(3,12)
                    .WithMessage("{PropertyName} '{PropertyValue}' must be minimum 3 and maximum 12 symbols lenght")
                    .WithErrorCode("PP301")
                .Matches("^([A-Za-z0-9_]+){3,12}$")
                    .WithMessage("{PropertyName} '{PropertyValue}' must contain only 'AZ az 09 and _'. No spaces")
                    .WithErrorCode("PP302");
            RuleFor(x => x.ToTemplate)
                .Length(3, 12)
                    .WithMessage("{PropertyName} '{PropertyValue}' must be minimum 3 and maximum 12 symbols lenght")
                    .WithErrorCode("PP303")
                .Matches("^([A-Za-z0-9_]+)$")
                    .WithMessage("{PropertyName} '{PropertyValue}' must contain only 'AZ az 09 and _'. No spaces")
                    .WithErrorCode("PP304");
        }
    }
}

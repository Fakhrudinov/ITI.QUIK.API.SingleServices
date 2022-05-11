using DataAbstraction.Models;
using FluentValidation;

namespace DataValidationService
{
    public class FortsCodeAndPubringKeyModelValidationService : AbstractValidator<FortsCodeAndPubringKeyModel>
    {
        public FortsCodeAndPubringKeyModelValidationService()
        {
            RuleFor(x => x.ClientCode.FortsClientCode)
                .Matches("^C0[0-9A-Za-z]{5}$")
                    .WithMessage("{PropertyName} '{PropertyValue}' is not in format 'C0xxxxx'.")
                    .WithErrorCode("PP760");

            RuleFor(x => x.Key.KeyID)
                .Length(16)
                    .WithMessage("{PropertyName} '{PropertyValue}' must be 16 symbols lenght")
                    .WithErrorCode("PP927");
            RuleFor(x => x.Key.Time)
                .GreaterThan(0)
                    .WithMessage("{PropertyName} '{PropertyValue}' must be Greater Than 0")
                    .WithErrorCode("PP928");
            RuleFor(x => x.Key.RSAKey)
                .Length(64)
                    .WithMessage("{PropertyName} '{PropertyValue}' must be 64 symbols lenght")
                    .WithErrorCode("PP929");
        }
    }
}

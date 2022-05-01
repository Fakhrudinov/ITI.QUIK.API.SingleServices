using FluentValidation;

namespace DataValidationService
{
    public class SingleFortsCodeStringValidationService : AbstractValidator<string>
    {
        public SingleFortsCodeStringValidationService()
        {
            RuleFor(x => x)
                .Matches("^C0[0-9A-Za-z]{5}")
                    .WithMessage("{PropertyName} '{PropertyValue}' is not in format 'C0xxxxx'.")
                    .WithErrorCode("PP701");
        }
    }
}

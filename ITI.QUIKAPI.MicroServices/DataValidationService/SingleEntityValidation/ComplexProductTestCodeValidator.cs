using FluentValidation;

namespace DataValidationService.SingleEntityValidation
{
    internal class ComplexProductTestCodeValidator : AbstractValidator<string>
    {
        internal ComplexProductTestCodeValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                    .WithMessage("Test '{PropertyValue}' must contain value")
                    .WithErrorCode("CPT100")
                .Matches("^[-]{0,1}[0-9]{1,4}$")
                    .WithMessage("{PropertyName} '{PropertyValue}' must be a string represent number (can be negative)")
                    .WithErrorCode("CPT101");
        }
    }
}

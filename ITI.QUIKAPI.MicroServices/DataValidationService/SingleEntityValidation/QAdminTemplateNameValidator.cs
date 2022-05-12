using FluentValidation;

namespace DataValidationService.SingleEntityValidation
{
    internal class QAdminTemplateNameValidator : AbstractValidator<string>
    {
        internal QAdminTemplateNameValidator()
        {
            RuleFor(x => x)
                .Length(3, 12)
                    .WithMessage("{PropertyName} '{PropertyValue}' must be minimum 3 and maximum 12 symbols lenght")
                    .WithErrorCode("QT100")
                .Matches("^([A-Za-z0-9_]+){3,12}$")
                    .WithMessage("{PropertyName} '{PropertyValue}' must contain only 'AZ az 09 and _'. No spaces")
                    .WithErrorCode("QT101");
        }
    }
}

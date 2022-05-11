using FluentValidation;

namespace DataValidationService.SingleEntityValidation
{
    internal class ClientCodeSpotQuikValidator : AbstractValidator<string>
    {
        internal ClientCodeSpotQuikValidator()
        {
            RuleFor(x => x)
                .Matches("^B[PC][0-9]{4,6}\\/[D]{0,1}[0-9]{2}$")
                    .WithMessage("{PropertyName} '{PropertyValue}' is not in format 'BP12345/01' or 'BP12345/D01'")
                    .WithErrorCode("QS100");
        }
    }
}

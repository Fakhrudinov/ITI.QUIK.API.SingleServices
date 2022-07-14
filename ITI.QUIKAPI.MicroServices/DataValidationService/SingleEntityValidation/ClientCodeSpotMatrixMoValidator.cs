using FluentValidation;

namespace DataValidationService.SingleEntityValidation
{
    internal class ClientCodeSpotMatrixMoValidator : AbstractValidator<string>
    {
        internal ClientCodeSpotMatrixMoValidator()
        {
            RuleFor(x => x)
                .Matches("^(AA|B[PC])[0-9]{4,6}-MO-[0-9]{2}$")
                    .WithMessage("{PropertyName} '{PropertyValue}' is not in format 'BP12345-MO-01'. Accept only MO portfolio")
                    .WithErrorCode("MS103");
        }
    }
}

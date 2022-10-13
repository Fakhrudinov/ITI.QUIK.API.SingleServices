using FluentValidation;

namespace DataValidationService.SingleEntityValidation
{
    internal class ClientCodeSpotMatrixCdValidator : AbstractValidator<string>
    {
        internal ClientCodeSpotMatrixCdValidator()
        {
            RuleFor(x => x)
                .Matches("^(AA|B[PC])[0-9]{4,6}-CD-[0-9]{2,3}$")
                    .WithMessage("{PropertyName} '{PropertyValue}' is not in format 'BP12345-CD-01'")
                    .WithErrorCode("MS101");
        }
    }
}

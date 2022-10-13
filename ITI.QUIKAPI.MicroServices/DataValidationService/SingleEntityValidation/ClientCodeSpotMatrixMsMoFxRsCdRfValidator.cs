using FluentValidation;

namespace DataValidationService.SingleEntityValidation
{
    internal class ClientCodeSpotMatrixMsMoFxRsCdRfValidator : AbstractValidator<string>
    {
        internal ClientCodeSpotMatrixMsMoFxRsCdRfValidator()
        {
            RuleFor(x => x)
                .Matches("^(AA|B[PC])[0-9]{4,6}-(MS|MO|FX|RS|CD|RF)-[0-9]{2,3}$")
                    .WithMessage("{PropertyName} '{PropertyValue}' is not in format 'BP12345-XX-01'. Accept only MS|MO|FX|RS|CD|RF portfolio")
                    .WithErrorCode("MS106");
        }
    }
}

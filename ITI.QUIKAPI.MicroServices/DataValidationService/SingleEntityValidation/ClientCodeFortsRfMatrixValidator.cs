using FluentValidation;

namespace DataValidationService.SingleEntityValidation 
{
    internal class ClientCodeFortsRfMatrixValidator : AbstractValidator<string>
    {
        internal ClientCodeFortsRfMatrixValidator()
        {
            RuleFor(x => x)
                .Matches("^(AA|B[PC])[0-9]{4,6}-RF-[0-9]{2,3}$")
                    .WithMessage("{PropertyName} '{PropertyValue}' is not in format 'BP12345-RF-01'. Accept only RF portfolio")
                    .WithErrorCode("MF101");
        }
    }
}

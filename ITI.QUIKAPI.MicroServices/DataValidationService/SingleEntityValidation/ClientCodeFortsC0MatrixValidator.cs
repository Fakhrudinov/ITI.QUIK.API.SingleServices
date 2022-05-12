using FluentValidation;

namespace DataValidationService.SingleEntityValidation
{
    internal class ClientCodeFortsC0MatrixValidator : AbstractValidator<string>
    {
        internal ClientCodeFortsC0MatrixValidator()
        {
            RuleFor(x => x)
                .Matches("^C0[0-9A-Za-z]{5}$")
                    .WithMessage("{PropertyName} '{PropertyValue}' is not in format 'C0xxxxx'.")
                    .WithErrorCode("MF100");
        }
    }
}

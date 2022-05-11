using DataAbstraction.Models;
using FluentValidation;

namespace DataValidationService
{
    public class MatrixCodeAndPubringKeyModelValidationService : AbstractValidator<MatrixCodeAndPubringKeyModel>
    {
        public MatrixCodeAndPubringKeyModelValidationService()
        {
            RuleFor(x => x.ClientCode.MatrixClientCode)
                .Matches("^B[PC][0-9]{4,6}-(MS|MO|FX|RS)-[0-9]{2}$")
                    .WithMessage("{PropertyName} '{PropertyValue}' is not in format 'BP12345-XX-01'. Accept only MS|MO|FX|RS portfolio")
                    .WithErrorCode("PP750");

            RuleFor(x => x.Key.KeyID)
                .Length(16)
                    .WithMessage("{PropertyName} '{PropertyValue}' must be 16 symbols lenght")
                    .WithErrorCode("PP917");
                        RuleFor(x => x.Key.Time)
                            .GreaterThan(0)
                                .WithMessage("{PropertyName} '{PropertyValue}' must be Greater Than 0")
                                .WithErrorCode("PP918");
            RuleFor(x => x.Key.RSAKey)
                .Length(64)
                    .WithMessage("{PropertyName} '{PropertyValue}' must be 64 symbols lenght")
                    .WithErrorCode("PP919");
        }
    }
}

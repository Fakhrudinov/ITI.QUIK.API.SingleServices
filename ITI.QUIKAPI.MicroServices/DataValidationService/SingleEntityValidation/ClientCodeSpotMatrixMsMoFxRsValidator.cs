﻿using FluentValidation;

namespace DataValidationService.SingleEntityValidation
{
    internal class ClientCodeSpotMatrixMsMoFxRsValidator : AbstractValidator<string>
    {
        internal ClientCodeSpotMatrixMsMoFxRsValidator()
        {
            RuleFor(x => x)
                .Matches("^(AA|B[PC])[0-9]{4,6}-(MS|MO|FX|RS)-[0-9]{2}$")
                    .WithMessage("{PropertyName} '{PropertyValue}' is not in format 'BP12345-XX-01'. Accept only MS|MO|FX|RS portfolio")
                    .WithErrorCode("MS102");
        }
    }
}

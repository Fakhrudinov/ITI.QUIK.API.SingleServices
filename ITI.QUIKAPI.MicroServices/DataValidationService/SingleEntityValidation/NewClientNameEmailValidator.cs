using DataAbstraction.Models;
using FluentValidation;

namespace DataValidationService.SingleEntityValidation
{
    internal class NewClientNameEmailValidator : AbstractValidator<ClientInformationModel>
{
        internal NewClientNameEmailValidator()
        {
            RuleFor(x => x.FirstName)
                .Length(2, 127)
                    .WithMessage("{PropertyName} '{PropertyValue}' must be minimum 2 and maximum 127 symbols lenght")
                    .WithErrorCode("CN100");
            RuleFor(x => x.LastName)
                .Length(2, 127)
                    .WithMessage("{PropertyName} '{PropertyValue}' must be minimum 2 and maximum 127 symbols lenght")
                    .WithErrorCode("CN101");

            RuleFor(x => x.EMail)
                .Length(7, 127)
                    .WithMessage("{PropertyName} '{PropertyValue}' must be minimum 7 and maximum 127 symbols lenght")
                    .WithErrorCode("CN102")
                .Matches(@"^[A-Z0-9a-z._%-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$")
                    .WithMessage("{PropertyName} '{PropertyValue}' regex not match Email")
                    .WithErrorCode("CN103");
        }
    }
}

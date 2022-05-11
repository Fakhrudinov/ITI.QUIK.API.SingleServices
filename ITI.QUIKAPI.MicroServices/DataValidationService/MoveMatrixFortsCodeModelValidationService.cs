using DataAbstraction.Models;
using DataValidationService.SingleEntityValidation;
using FluentValidation;

namespace DataValidationService
{
    public class MoveMatrixFortsCodeModelValidationService : AbstractValidator<MoveMatrixFortsCodeModel>
    {
        public MoveMatrixFortsCodeModelValidationService()
        {
            //RuleFor(x => x.ClientCode)
            //    .Matches("^C0[0-9A-Za-z]{5}$")
            //        .WithMessage("{PropertyName} '{PropertyValue}' is not in format 'C0xxxxx'.")
            //        .WithErrorCode("PP320");
            RuleFor(x => x.ClientCode).SetValidator(new ClientCodeFortsC0MatrixValidator());
            RuleFor(x => x.FromTemplate).SetValidator(new QAdminTemplateNameValidator());
            RuleFor(x => x.ToTemplate).SetValidator(new QAdminTemplateNameValidator());

            //RuleFor(x => x.FromTemplate)
            //    .Length(3, 12)
            //        .WithMessage("{PropertyName} '{PropertyValue}' must be minimum 3 and maximum 12 symbols lenght")
            //        .WithErrorCode("PP321")
            //    .Matches("^([A-Za-z0-9_]+){3,12}$")
            //        .WithMessage("{PropertyName} '{PropertyValue}' must contain only 'AZ az 09 and _'. No spaces")
            //        .WithErrorCode("PP322");
            //RuleFor(x => x.ToTemplate)
            //    .Length(3, 12)
            //        .WithMessage("{PropertyName} '{PropertyValue}' must be minimum 3 and maximum 12 symbols lenght")
            //        .WithErrorCode("PP323")
            //    .Matches("^([A-Za-z0-9_]+)$")
            //        .WithMessage("{PropertyName} '{PropertyValue}' must contain only 'AZ az 09 and _'. No spaces")
            //        .WithErrorCode("PP324");
        }
    }
}

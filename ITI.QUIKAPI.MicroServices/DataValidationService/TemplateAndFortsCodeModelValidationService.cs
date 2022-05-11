using DataAbstraction.Models;
using DataValidationService.SingleEntityValidation;
using FluentValidation;

namespace DataValidationService
{
    public class TemplateAndFortsCodeModelValidationService : AbstractValidator<TemplateAndFortsCodeModel>
    {
        public TemplateAndFortsCodeModelValidationService()
        {
            //RuleFor(x => x.ClientCode)
            //    .Matches("^C0[0-9A-Za-z]{5}$")
            //        .WithMessage("{PropertyName} '{PropertyValue}' is not in format 'C0xxxxx'.")
            //        .WithErrorCode("PP510");
            RuleFor(x => x.ClientCode).SetValidator(new ClientCodeFortsC0MatrixValidator());
            RuleFor(x => x.Template).SetValidator(new QAdminTemplateNameValidator());

            //RuleFor(x => x.Template)
            //    .Length(3, 12)
            //        .WithMessage("{PropertyName} '{PropertyValue}' must be minimum 3 and maximum 12 symbols lenght")
            //        .WithErrorCode("PP511")
            //    .Matches("^([A-Za-z0-9_]+)$")
            //        .WithMessage("{PropertyName} '{PropertyValue}' must contain only 'AZ az 09 and _'. No spaces")
            //        .WithErrorCode("PP512");
        }
    }
}

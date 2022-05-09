using DataAbstraction.Models;
using FluentValidation;

namespace DataValidationService
{
    internal class TemplateAndMatrixFortsCodesModelValidationService : AbstractValidator<TemplateAndMatrixFortsCodesModel>
    {
        public TemplateAndMatrixFortsCodesModelValidationService()
        {
            RuleForEach(x => x.ClientCodes).ChildRules(codes =>
            {
                codes.RuleFor(x => x.FortsClientCode)
                    .Matches("^C0[0-9A-Za-z]{5}$")
                        .WithMessage("{PropertyName} '{PropertyValue}' is not in format 'C0xxxxx'.")
                        .WithErrorCode("PP610");
            });

            RuleFor(x => x.Template)
                .Length(3, 12)
                    .WithMessage("{PropertyName} '{PropertyValue}' must be minimum 3 and maximum 12 symbols lenght")
                    .WithErrorCode("PP611")
                .Matches("^([A-Za-z0-9_]+)$")
                    .WithMessage("{PropertyName} '{PropertyValue}' must contain only 'AZ az 09 and _'. No spaces")
                    .WithErrorCode("PP612");
        }
    }
}

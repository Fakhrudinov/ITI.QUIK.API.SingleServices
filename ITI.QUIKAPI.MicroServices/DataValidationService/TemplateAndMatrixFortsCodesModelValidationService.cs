using DataAbstraction.Models;
using DataValidationService.SingleEntityValidation;
using FluentValidation;

namespace DataValidationService
{
    internal class TemplateAndMatrixFortsCodesModelValidationService : AbstractValidator<TemplateAndMatrixFortsCodesModel>
    {
        public TemplateAndMatrixFortsCodesModelValidationService()
        {
            RuleForEach(x => x.ClientCodes).ChildRules(codes =>
            {
                codes.RuleFor(x => x.FortsClientCode).SetValidator(new ClientCodeFortsC0MatrixValidator());
            });

            RuleFor(x => x.Template).SetValidator(new QAdminTemplateNameValidator());
        }
    }
}

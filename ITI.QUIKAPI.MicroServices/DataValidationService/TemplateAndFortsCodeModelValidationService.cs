using DataAbstraction.Models;
using DataValidationService.SingleEntityValidation;
using FluentValidation;

namespace DataValidationService
{
    public class TemplateAndFortsCodeModelValidationService : AbstractValidator<TemplateAndFortsCodeModel>
    {
        public TemplateAndFortsCodeModelValidationService()
        {
            RuleFor(x => x.ClientCode).SetValidator(new ClientCodeFortsC0MatrixValidator());
            RuleFor(x => x.Template).SetValidator(new QAdminTemplateNameValidator());
        }
    }
}

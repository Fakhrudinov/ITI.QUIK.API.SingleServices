using DataAbstraction.Models;
using DataValidationService.SingleEntityValidation;
using FluentValidation;

namespace DataValidationService
{
    public class TemplateAndMatrixCodeModelValidationService : AbstractValidator<TemplateAndMatrixCodeModel>
    {
        public TemplateAndMatrixCodeModelValidationService()
        {
            RuleFor(x => x.MatrixClientPortfolio).SetValidator(new ClientCodeSpotMatrixMsMoFxRsCdValidator());
            RuleFor(x => x.Template).SetValidator(new QAdminTemplateNameValidator());
        }
    }
}

using DataAbstraction.Models;
using DataValidationService.SingleEntityValidation;
using FluentValidation;

namespace DataValidationService
{
    public class MoveMatrixCodeModelValidationService : AbstractValidator<MoveMatrixCodeModel>
    {
        public MoveMatrixCodeModelValidationService()
        {
            RuleFor(x => x.ClientCode).SetValidator(new ClientCodeSpotMatrixMsMoFxRsCdValidator());
            RuleFor(x => x.FromTemplate).SetValidator(new QAdminTemplateNameValidator());
            RuleFor(x => x.ToTemplate).SetValidator(new QAdminTemplateNameValidator());
        }
    }
}

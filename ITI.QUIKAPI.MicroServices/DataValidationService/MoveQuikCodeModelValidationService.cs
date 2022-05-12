using DataAbstraction.Models;
using DataValidationService.SingleEntityValidation;
using FluentValidation;

namespace DataValidationService
{
    public class MoveQuikCodeModelValidationService : AbstractValidator<MoveQuikCodeModel>
    {
        public MoveQuikCodeModelValidationService()
        {
            RuleFor(x => x.ClientCode).SetValidator(new ClientCodeSpotQuikValidator());
            RuleFor(x => x.FromTemplate).SetValidator(new QAdminTemplateNameValidator());
            RuleFor(x => x.ToTemplate).SetValidator(new QAdminTemplateNameValidator());
        }
    }
}

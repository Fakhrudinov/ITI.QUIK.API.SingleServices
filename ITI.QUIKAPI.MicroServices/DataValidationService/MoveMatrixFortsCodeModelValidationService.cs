using DataAbstraction.Models;
using DataValidationService.SingleEntityValidation;
using FluentValidation;

namespace DataValidationService
{
    public class MoveMatrixFortsCodeModelValidationService : AbstractValidator<MoveMatrixFortsCodeModel>
    {
        public MoveMatrixFortsCodeModelValidationService()
        {
            RuleFor(x => x.FortsClientCode).SetValidator(new ClientCodeFortsC0MatrixValidator());
            RuleFor(x => x.FromTemplate).SetValidator(new QAdminTemplateNameValidator());
            RuleFor(x => x.ToTemplate).SetValidator(new QAdminTemplateNameValidator());
        }
    }
}

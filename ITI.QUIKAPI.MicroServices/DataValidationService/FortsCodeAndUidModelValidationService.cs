using DataAbstraction.Models;
using DataValidationService.SingleEntityValidation;
using FluentValidation;

namespace DataValidationService
{
    internal class FortsCodeAndUidModelValidationService : AbstractValidator<FortsCodeAndUidModel>
    {
        public FortsCodeAndUidModelValidationService()
        {
            RuleFor(x => x.MatrixFortsCode).SetValidator(new ClientCodeFortsC0MatrixValidator());
        }
    }
}
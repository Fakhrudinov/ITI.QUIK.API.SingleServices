using DataAbstraction.Models;
using DataValidationService.SingleEntityValidation;
using FluentValidation;

namespace DataValidationService
{
    public class MatrixArrayCodesValidationService : AbstractValidator<CodesArrayModel>
    {
        public MatrixArrayCodesValidationService()
        {
            RuleForEach(x => x.ClientCodes).ChildRules(codes =>
            {
                codes.RuleFor(x => x.MatrixClientCode).SetValidator(new ClientCodeSpotMatrixMsMoFxRsCdValidator());
            });
        }
    }
}

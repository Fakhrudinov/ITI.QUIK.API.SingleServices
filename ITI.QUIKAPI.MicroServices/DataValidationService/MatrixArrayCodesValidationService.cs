using DataAbstraction.Models;
using DataValidationService.SingleEntityValidation;
using FluentValidation;

namespace DataValidationService
{
    public class MatrixArrayCodesValidationService : AbstractValidator<CodesArrayModel>
    {
        public MatrixArrayCodesValidationService()
        {
            RuleForEach(x => x.MatrixClientPortfolios).ChildRules(codes =>
            {
                codes.RuleFor(x => x.MatrixClientPortfolio).SetValidator(new ClientCodeSpotMatrixMsMoFxRsCdValidator());
            });
        }
    }
}

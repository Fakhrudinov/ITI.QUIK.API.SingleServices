using DataAbstraction.Models;
using DataValidationService.SingleEntityValidation;
using FluentValidation;

namespace DataValidationService
{
    internal class MatrixPortfolioAndUidModelValidationService : AbstractValidator<MatrixPortfolioAndUidModel>
    {
        public MatrixPortfolioAndUidModelValidationService()
        {
            RuleFor(x => x.MatrixPortfolio.MatrixClientPortfolio).SetValidator(new ClientCodeSpotMatrixMsMoFxRsCdValidator());
        }
    }
}
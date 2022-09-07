using DataAbstraction.Models;
using DataValidationService.SingleEntityValidation;
using FluentValidation;

namespace DataValidationService
{
    internal class QCodeAndListOfComplexProductsTestsValidationService : AbstractValidator<QCodeAndListOfComplexProductsTestsModel[]>
    {
        public QCodeAndListOfComplexProductsTestsValidationService()
        {
            RuleForEach(x => x).ChildRules(codes =>
            {
                codes.RuleFor(x => x.QuikClientCode).SetValidator(new ClientCodeSpotQuikValidator());
                
                codes.RuleFor(x => x.RestrictionCodes)
                    .ChildRules(tests => 
                        tests.RuleForEach(z => z).SetValidator(new ComplexProductTestCodeValidator()));
            });
        }
    }
}

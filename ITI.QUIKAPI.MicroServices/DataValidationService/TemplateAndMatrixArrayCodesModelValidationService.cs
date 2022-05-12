using DataAbstraction.Models;
using DataValidationService.SingleEntityValidation;
using FluentValidation;


namespace DataValidationService
{
    public class TemplateAndMatrixArrayCodesModelValidationService : AbstractValidator<TemplateAndMatrixCodesModel>
    {
        public TemplateAndMatrixArrayCodesModelValidationService()
        {
            RuleForEach(x => x.ClientCodes).ChildRules(codes =>
            {
                codes.RuleFor(x => x.MatrixClientCode).SetValidator(new ClientCodeSpotMatrixMsMoFxRsCdValidator());
            });

            RuleFor(x => x.Template).SetValidator(new QAdminTemplateNameValidator());
        }
    }
}

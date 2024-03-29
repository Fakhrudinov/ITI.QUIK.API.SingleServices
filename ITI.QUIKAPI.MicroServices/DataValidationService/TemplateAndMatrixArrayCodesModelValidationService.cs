﻿using DataAbstraction.Models;
using DataValidationService.SingleEntityValidation;
using FluentValidation;


namespace DataValidationService
{
    public class TemplateAndMatrixArrayCodesModelValidationService : AbstractValidator<TemplateAndMatrixCodesModel>
    {
        public TemplateAndMatrixArrayCodesModelValidationService()
        {
            RuleForEach(x => x.MatrixClientPortfolio).ChildRules(codes =>
            {
                codes.RuleFor(x => x.MatrixClientPortfolio).SetValidator(new ClientCodeSpotMatrixMsMoFxRsCdValidator());
            });

            RuleFor(x => x.Template).SetValidator(new QAdminTemplateNameValidator());
        }
    }
}

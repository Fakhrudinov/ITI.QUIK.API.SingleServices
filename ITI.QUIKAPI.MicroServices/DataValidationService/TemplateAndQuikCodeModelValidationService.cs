﻿using DataAbstraction.Models;
using DataValidationService.SingleEntityValidation;
using FluentValidation;

namespace DataValidationService
{
    public class TemplateAndQuikCodeModelValidationService : AbstractValidator<TemplateAndQuikCodeModel>
    {
        public TemplateAndQuikCodeModelValidationService()
        {
            RuleFor(x => x.ClientCode).SetValidator(new ClientCodeSpotQuikValidator());
            RuleFor(x => x.Template).SetValidator(new QAdminTemplateNameValidator());
        }
    }
}

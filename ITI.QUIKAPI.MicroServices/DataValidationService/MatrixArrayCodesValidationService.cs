using DataAbstraction.Models;
using FluentValidation;

namespace DataValidationService
{
    public class MatrixArrayCodesValidationService : AbstractValidator<CodesArrayModel>
    {
        public MatrixArrayCodesValidationService()
        {
            RuleForEach(x => x.ClientCodes).ChildRules(codes =>
            {
                codes.RuleFor(x => x.MatrixClientCode).Matches("^B[PC][0-9]{4,6}-(MS|MO|CD|FX|RS)-[0-9]{2}$")
                    .WithMessage("{PropertyName} '{PropertyValue}' is not in format 'BP12345-XX-01'. Accept only MS|MO|CD|FX|RS portfolio")
                    .WithErrorCode("PP200");
            });
        }
    }
}

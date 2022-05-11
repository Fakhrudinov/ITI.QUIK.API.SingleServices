using DataAbstraction.Models;
using DataValidationService.SingleEntityValidation;
using FluentValidation;

namespace DataValidationService
{
    public class MatrixToFortsCodeMappingModelValidationService : AbstractValidator<MatrixToFortsCodesMappingModel>
    {
        public MatrixToFortsCodeMappingModelValidationService()
        {
            //RuleFor(x => x.MatrixClientCode)
            //    .Matches("^B[PC][0-9]{4,6}-MO-[0-9]{2}$")
            //        .WithMessage("{PropertyName} '{PropertyValue}' is not in format 'BP12345-MO-01'. Accept only MO portfolio")
            //        .WithErrorCode("PP720");

            RuleFor(x => x.MatrixClientCode).SetValidator(new ClientCodeSpotMatrixMoValidator());
            RuleFor(x => x.FortsClientCode).SetValidator(new ClientCodeFortsC0MatrixValidator());
            //RuleFor(x => x.FortsClientCode)
            //    .Matches("^C0[0-9A-Za-z]{5}$")
            //        .WithMessage("{PropertyName} '{PropertyValue}' is not in format 'C0xxxxx'.")
            //        .WithErrorCode("PP721");

        }
    }
}

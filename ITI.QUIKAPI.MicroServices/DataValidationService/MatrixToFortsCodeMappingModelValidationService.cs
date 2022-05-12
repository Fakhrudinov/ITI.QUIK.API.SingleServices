using DataAbstraction.Models;
using DataValidationService.SingleEntityValidation;
using FluentValidation;

namespace DataValidationService
{
    public class MatrixToFortsCodeMappingModelValidationService : AbstractValidator<MatrixToFortsCodesMappingModel>
    {
        public MatrixToFortsCodeMappingModelValidationService()
        {
            RuleFor(x => x.MatrixClientCode).SetValidator(new ClientCodeSpotMatrixMoValidator());
            RuleFor(x => x.FortsClientCode).SetValidator(new ClientCodeFortsC0MatrixValidator());
        }
    }
}

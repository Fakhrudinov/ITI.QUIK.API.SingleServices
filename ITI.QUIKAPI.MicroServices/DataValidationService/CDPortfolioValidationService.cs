//using DataAbstraction.Models;
//using DataValidationService.SingleEntityValidation;
//using FluentValidation;

//namespace DataValidationService
//{
//    public class CDPortfolioValidationService : AbstractValidator<MatrixClientCodeModel>
//    {
//        public CDPortfolioValidationService()
//        {
//            RuleFor(x => x.MatrixClientCode).SetValidator(new ClientCodeSpotMatrixCdValidator());
//            //RuleFor(x => x.MatrixClientCode)
//            //    .Matches("^B[PC][0-9]{4,6}-CD-[0-9]{2}$")
//            //        .WithMessage("Portfolio '{PropertyValue}' is not in format 'BP12345-CD-01'")
//            //        .WithErrorCode("PP100");
//        }
//    }
//}
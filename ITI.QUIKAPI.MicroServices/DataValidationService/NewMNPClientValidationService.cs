using DataAbstraction.Models.DataBaseModels;
using DataValidationService.SingleEntityValidation;
using FluentValidation;

namespace DataValidationService
{
    public class NewMNPClientValidationService : AbstractValidator<NewMNPClientModel>
    {
        public NewMNPClientValidationService()
        {
            RuleForEach(x => x.CodesMatrix).ChildRules(codes =>
            {
                codes.RuleFor(x => x.MatrixClientCode).SetValidator(new ClientCodeSpotMatrixMsMoFxRsCdValidator());
            });

            RuleForEach(x => x.CodesPairRF).ChildRules(codes =>
            {
                codes.RuleFor(x => x.MatrixClientCode).SetValidator(new ClientCodeFortsRfMatrixValidator());
            });

            RuleForEach(x => x.CodesPairRF).ChildRules(codes =>
            {
                codes.RuleFor(x => x.FortsClientCode).SetValidator(new ClientCodeFortsC0MatrixValidator());
            });

            RuleFor(x => x.Client).SetValidator(new NewClientNameEmailValidator());

            RuleFor(x => x.CodesMatrix)
               .NotEmpty()
                   .When(x => x.CodesPairRF == null)
                   .WithMessage("MO MS FX CD RS Portfolios array 'CodesMatrix' must be Greater Than 0 when RF portfolios array 'CodesPairRF' is not set")
                   .WithErrorCode("MNP100");
            RuleFor(x => x.CodesPairRF)
                .NotEmpty()
                    .When(x => x.CodesMatrix == null)
                    .WithMessage("RF portfolios array 'CodesPairRF' must be Greater Than 0 when MO MS FX CD RS Portfolios array 'CodesMatrix' is not set")
                    .WithErrorCode("MNP100");


            RuleFor(x => x.Address)
                .NotNull()
                    .WithMessage("{PropertyName} {PropertyValue} must be not null")
                    .WithErrorCode("MNP100")
                .Length(2, 254)
                    .WithMessage("{PropertyName} '{PropertyValue}' must be minimum 2 and maximum 254 symbols lenght")
                    .WithErrorCode("MNP100");



            RuleFor(x => x.RegisterDate)
                .GreaterThan(19950101)
                    .WithMessage("{PropertyName} {PropertyValue} is too small. Set agreement date in format 'yyyyMMdd'")
                    .WithErrorCode("MNP100")
                .LessThan(Int32.Parse(DateTime.Now.ToString("yyyyMMdd")) + 1)
                    .WithMessage("{PropertyName} {PropertyValue} is too big. Set agreement date in format 'yyyyMMdd'")
                    .WithErrorCode("MNP100");
            
            When(x => x.Number != null, () => 
            {
                RuleFor(x => x.Number)
                    .Length(2, 32)
                        .WithMessage("{PropertyName} '{PropertyValue}' must be minimum 2 and maximum 32 symbols lenght")
                        .WithErrorCode("MNP100");
            });

            When(x => x.SubAccount.Length > 0, () => 
            {
                RuleFor(x => x.SubAccount)
                    .Length(2, 32)
                        .WithMessage("{PropertyName} '{PropertyValue}' must be minimum 2 and maximum 32 symbols lenght")
                        .WithErrorCode("MNP100");
            });

            When(x => x.Depositary.Length > 0, () =>
            {
                RuleFor(x => x.Depositary)
                    .Length(2, 64)
                        .WithMessage("{PropertyName} '{PropertyValue}' must be minimum 2 and maximum 64 symbols lenght")
                        .WithErrorCode("MNP100");
            });

            When(x => x.Manager != null, () =>
            {
                RuleFor(x => x.Manager)
                    .Length(2, 255)
                        .WithMessage("{PropertyName} '{PropertyValue}' must be minimum 2 and maximum 255 symbols lenght")
                        .WithErrorCode("MNP100");
            });

            When(x => x.DepoClientAccountsManager.Length > 0, () =>
            {
                RuleFor(x => x.DepoClientAccountsManager)
                    .Length(2, 192)
                        .WithMessage("{PropertyName} '{PropertyValue}' must be minimum 2 and maximum 192 symbols lenght")
                        .WithErrorCode("MNP100");
            });

        }
    }
}

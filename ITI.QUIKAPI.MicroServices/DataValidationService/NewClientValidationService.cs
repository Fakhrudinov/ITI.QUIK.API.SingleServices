using DataAbstraction.Models;
using DataValidationService.SingleEntityValidation;
using FluentValidation;


namespace DataValidationService
{
    public class NewClientValidationService : AbstractValidator<NewClientModel>
    {
        public NewClientValidationService()
        {
            RuleForEach(x => x.CodesMatrix).ChildRules(codes =>
            {
                codes
                    .RuleFor(x => x.MatrixClientCode).SetValidator(new ClientCodeSpotMatrixMsMoFxRsCdValidator());
                    //.RuleFor(x => x.MatrixClientCode)
                    //    .Matches("^B[PC][0-9]{4,6}-(MS|MO|CD|FX|RS)-[0-9]{2}$")
                    //        .WithMessage("{PropertyName} '{PropertyValue}' is not in format 'BP12345-XX-01'. Accept only MS|MO|CD|FX|RS portfolio")
                    //        .WithErrorCode("PP900");
            });


            RuleForEach(x => x.CodesPairRF).ChildRules(codes =>
            {
                codes
                    .RuleFor(x => x.MatrixClientCode).SetValidator(new ClientCodeFortsRfMatrixValidator());
                    //.RuleFor(x => x.MatrixClientCode)
                    //    .Matches("^B[PC][0-9]{4,6}-RF-[0-9]{2}$")
                    //        .WithMessage("{PropertyName} '{PropertyValue}' is not in format 'BP12345-RF-01'. Accept only RF portfolio")
                    //        .WithErrorCode("PP901");
            });

            RuleForEach(x => x.CodesPairRF).ChildRules(codes =>
            {
                codes
                .RuleFor(x => x.FortsClientCode).SetValidator(new ClientCodeFortsC0MatrixValidator());
                //.RuleFor(x => x.FortsClientCode)
                //    .Matches("^C0[0-9A-Za-z]{5}$")
                //        .WithMessage("{PropertyName} '{PropertyValue}' is not in format 'C0xxxxx'.")
                //        .WithErrorCode("PP902");
            });

            RuleFor(x => x.Client).SetValidator(new NewClientNameEmailValidator());
            //RuleFor(x => x.Client.FirstName)
            //    .Length(2, 127)
            //        .WithMessage("{PropertyName} '{PropertyValue}' must be minimum 2 and maximum 127 symbols lenght")
            //        .WithErrorCode("PP903");
            //RuleFor(x => x.Client.LastName)
            //    .Length(2, 127)
            //        .WithMessage("{PropertyName} '{PropertyValue}' must be minimum 2 and maximum 127 symbols lenght")
            //        .WithErrorCode("PP904");
            //RuleFor(x => x.Client.EMail)
            //    .Length(7, 127)
            //        .WithMessage("{PropertyName} '{PropertyValue}' must be minimum 7 and maximum 127 symbols lenght")
            //        .WithErrorCode("PP905")
            //    .Matches(@"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$")
            //        .WithMessage("{PropertyName} '{PropertyValue}' regex not match Email")
            //        .WithErrorCode("PP906"); ;

            RuleFor(x => x.Key).SetValidator(new QAdminPubringKeyValidator());
            //RuleFor(x => x.Key.KeyID)
            //    .Length(16)
            //        .WithMessage("{PropertyName} '{PropertyValue}' must be 16 symbols lenght")
            //        .WithErrorCode("PP907");
            //RuleFor(x => x.Key.Time)
            //    .GreaterThan(0)
            //        .WithMessage("{PropertyName} '{PropertyValue}' must be Greater Than 0")
            //        .WithErrorCode("PP908");
            //RuleFor(x => x.Key.RSAKey)
            //    .Length(64)
            //        .WithMessage("{PropertyName} '{PropertyValue}' must be 64 symbols lenght")
            //        .WithErrorCode("PP909");


            RuleFor(x => x.CodesMatrix)
                .NotEmpty()
                    .When(x => x.CodesPairRF == null)
                    .WithMessage("MO MS FX CD RS Portfolios array 'CodesMatrix' must be Greater Than 0 when RF portfolios array 'CodesPairRF' is not set")
                    .WithErrorCode("PP910");
            RuleFor(x => x.CodesPairRF)
                .NotEmpty()
                    .When(x => x.CodesMatrix == null)
                    .WithMessage("RF portfolios array 'CodesPairRF' must be Greater Than 0 when MO MS FX CD RS Portfolios array 'CodesMatrix' is not set")
                    .WithErrorCode("PP911");

        }
    }
}

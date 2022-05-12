using DataAbstraction.Models;
using DataValidationService.SingleEntityValidation;
using FluentValidation;

namespace DataValidationService
{
    public class NewClientOptionWorkshopValidationService : AbstractValidator<NewClientOptionWorkShopModel>
    {
        public NewClientOptionWorkshopValidationService()
        {
            RuleFor(x => x.CodesPairRF).Must(x => x.Length > 0)
                    .WithMessage("{PropertyName} Должен быть как минимум 1 портфель/код в массиве CodesPair")
                    .WithErrorCode("PP800");
            RuleForEach(x => x.CodesPairRF).ChildRules(codes =>
            {
                codes
                    //.RuleFor(x => x.MatrixClientCode).Matches("^B[PC][0-9]{4,6}-RF-[0-9]{2}$")
                    //    .WithMessage("{PropertyName} '{PropertyValue}' is not in format 'BP12345-RF-01'. Accept only RF portfolio")
                    //    .WithErrorCode("PP801");
                    .RuleFor(x => x.MatrixClientCode).SetValidator(new ClientCodeFortsRfMatrixValidator());
            });

            RuleForEach(x => x.CodesPairRF).ChildRules(codes =>
            {
                codes
                //.RuleFor(x => x.FortsClientCode)
                //    .Matches("^C0[0-9A-Za-z]{5}$")
                //        .WithMessage("{PropertyName} '{PropertyValue}' is not in format 'C0xxxxx'.")
                //        .WithErrorCode("PP802");
                .RuleFor(x => x.FortsClientCode).SetValidator(new ClientCodeFortsC0MatrixValidator());
            });

            RuleFor(x => x.Client).SetValidator(new NewClientNameEmailValidator());
            //RuleFor(x => x.Client.FirstName)
            //    .Length(2, 127)
            //        .WithMessage("{PropertyName} '{PropertyValue}' must be minimum 2 and maximum 127 symbols lenght")
            //        .WithErrorCode("PP803");
            //RuleFor(x => x.Client.LastName)
            //    .Length(2, 127)
            //        .WithMessage("{PropertyName} '{PropertyValue}' must be minimum 2 and maximum 127 symbols lenght")
            //        .WithErrorCode("PP804");
            //RuleFor(x => x.Client.EMail)
            //    .Length(7, 127)
            //        .WithMessage("{PropertyName} '{PropertyValue}' must be minimum 7 and maximum 127 symbols lenght")
            //        .WithErrorCode("PP805")
            //    .Matches(@"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$")
            //        .WithMessage("{PropertyName} '{PropertyValue}' regex not match Email")
            //        .WithErrorCode("PP806");

            RuleFor(x => x.Key).SetValidator(new QAdminPubringKeyValidator());
            //RuleFor(x => x.Key.KeyID)
            //    .Length(16)
            //        .WithMessage("{PropertyName} '{PropertyValue}' must be 16 symbols lenght")
            //        .WithErrorCode("PP807");
            //RuleFor(x => x.Key.Time)
            //    .GreaterThan(0)
            //        .WithMessage("{PropertyName} '{PropertyValue}' must be Greater Than 0")
            //        .WithErrorCode("PP808");
            //RuleFor(x => x.Key.RSAKey)
            //    .Length(64)
            //        .WithMessage("{PropertyName} '{PropertyValue}' must be 64 symbols lenght")
            //        .WithErrorCode("PP809");

        }
    }
}

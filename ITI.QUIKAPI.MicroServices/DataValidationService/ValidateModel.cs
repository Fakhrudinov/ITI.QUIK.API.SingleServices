using DataAbstraction.Models;
using DataValidationService.SingleEntityValidation;
using FluentValidation.Results;

namespace DataValidationService
{
    public static class ValidateModel
    {
        public static ListStringResponseModel ValidateTemplateAndMatrixCodeModel(TemplateAndMatrixCodeModel model)
        {
            TemplateAndMatrixCodeModelValidationService validator = new TemplateAndMatrixCodeModelValidationService();
            ListStringResponseModel responseList = new ListStringResponseModel();

            ValidationResult validationResult = validator.Validate(model);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);
            }

            if (model.ClientCode.Contains("RF"))// наверно лишнее но пусть пока будет. Rf коды проверяются в Fluent validator
            {
                responseList.IsSuccess = false;
                responseList.Messages.Add("RF portfolio not allowed in SPOT BRL");
            }

            return responseList;
        }

        public static ListStringResponseModel ValidateMatrixSpotClientCodeModel(MatrixClientCodeModel model)
        {
            ClientCodeSpotMatrixMsMoFxRsValidator validator = new ClientCodeSpotMatrixMsMoFxRsValidator();
            var responseList = new ListStringResponseModel();

            ValidationResult validationResult = validator.Validate(model.MatrixClientCode);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);
            }

            return responseList;
        }

        public static ListStringResponseModel ValidateMatrixCDClientCodeModel(MatrixClientCodeModel model)
        {
            ClientCodeSpotMatrixCdValidator validator = new ClientCodeSpotMatrixCdValidator();
            var responseList = new ListStringResponseModel();

            ValidationResult validationResult = validator.Validate(model.MatrixClientCode);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);
            }

            return responseList;
        }

        public static ListStringResponseModel ValidateMatrixFortsClientCodeModel(string code)
        {
            ClientCodeFortsC0MatrixValidator validator = new ClientCodeFortsC0MatrixValidator();
            var responseList = new ListStringResponseModel();

            ValidationResult validationResult = validator.Validate(code);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);
            }

            return responseList;
        }

        public static ListStringResponseModel ValidateTemplateAndQuikCodeModel(TemplateAndQuikCodeModel model)
        {
            TemplateAndQuikCodeModelValidationService validator = new TemplateAndQuikCodeModelValidationService();
            var responseList = new ListStringResponseModel();

            ValidationResult validationResult = validator.Validate(model);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);
            }

            return responseList;
        }

        public static ListStringResponseModel ValidateMatrixToFortsCodesMappingModel(MatrixToFortsCodesMappingModel model)
        {
            MatrixToFortsCodeMappingModelValidationService validator = new MatrixToFortsCodeMappingModelValidationService();
            var responseList = new ListStringResponseModel();

            ValidationResult validationResult = validator.Validate(model);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);
            }

            return responseList;
        }

        public static ListStringResponseModel ValidateQuikMoveCodeModel(MoveQuikCodeModel model)
        {
            MoveQuikCodeModelValidationService validator = new MoveQuikCodeModelValidationService();
            var responseList = new ListStringResponseModel();

            ValidationResult validationResult = validator.Validate(model);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);
            }

            return responseList;
        }

        public static ListStringResponseModel ValidateMatrixMoveCodeModel(MoveMatrixCodeModel model)
        {
            MoveMatrixCodeModelValidationService validator = new MoveMatrixCodeModelValidationService();
            var responseList = new ListStringResponseModel();

            ValidationResult validationResult = validator.Validate(model);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);
            }

            return responseList;
        }

        public static ListStringResponseModel ValidateTemplateAndMatrixCodesModel(TemplateAndMatrixCodesModel model)
        {
            var responseList = new ListStringResponseModel();
            TemplateAndMatrixArrayCodesModelValidationService validator = new TemplateAndMatrixArrayCodesModelValidationService();
            ValidationResult validationResult = validator.Validate(model);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);
            }

            return responseList;
        }

        public static ListStringResponseModel ValidateTemplateAndFortsCodeModel(TemplateAndFortsCodeModel model)
        {
            TemplateAndFortsCodeModelValidationService validator = new TemplateAndFortsCodeModelValidationService();
            ListStringResponseModel responseList = new ListStringResponseModel();

            ValidationResult validationResult = validator.Validate(model);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);
            }

            return responseList;
        }

        public static ListStringResponseModel ValidateNewClientOptionWorkShopModel(NewClientOptionWorkShopModel model)
        {
            NewClientOptionWorkshopValidationService validator = new NewClientOptionWorkshopValidationService();
            ListStringResponseModel responseList = new ListStringResponseModel();

            ValidationResult validationResult = validator.Validate(model);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);
            }

            return responseList;
        }

        public static ListStringResponseModel ValidateMatrixFortsCodeModel(MoveMatrixFortsCodeModel model)
        {
            MoveMatrixFortsCodeModelValidationService validator = new MoveMatrixFortsCodeModelValidationService();
            ListStringResponseModel responseList = new ListStringResponseModel();

            ValidationResult validationResult = validator.Validate(model);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);
            }

            return responseList;
        }

        public static ListStringResponseModel ValidateTemplateAnMatrixFortsCodesModel(TemplateAndMatrixFortsCodesModel model)
        {
            TemplateAndMatrixFortsCodesModelValidationService validator = new TemplateAndMatrixFortsCodesModelValidationService();
            ListStringResponseModel responseList = new ListStringResponseModel();

            ValidationResult validationResult = validator.Validate(model);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);
            }

            return responseList;
        }

        public static ListStringResponseModel ValidateTemplateName(string templateName)
        {
            QAdminTemplateNameValidator validator = new QAdminTemplateNameValidator();
            ListStringResponseModel responseList = new ListStringResponseModel();

            ValidationResult validationResult = validator.Validate(templateName);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);
            }

            return responseList;
        }

        public static ListStringResponseModel ValidateNewClientModel(NewClientModel model)
        {
            NewClientValidationService validator = new NewClientValidationService();
            ListStringResponseModel responseList = new ListStringResponseModel();

            ValidationResult validationResult = validator.Validate(model);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);
            }

            return responseList;
        }

        public static ListStringResponseModel ValidateMatrixCodeAndPubringKeyModel(MatrixCodeAndPubringKeyModel model)
        {
            MatrixCodeAndPubringKeyModelValidationService validator = new MatrixCodeAndPubringKeyModelValidationService();
            ListStringResponseModel responseList = new ListStringResponseModel();

            ValidationResult validationResult = validator.Validate(model);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);
            }

            return responseList;
        }

        public static ListStringResponseModel ValidateFortsCodeAndPubringKeyModel(FortsCodeAndPubringKeyModel model)
        {
            FortsCodeAndPubringKeyModelValidationService validator = new FortsCodeAndPubringKeyModelValidationService();
            ListStringResponseModel responseList = new ListStringResponseModel();

            ValidationResult validationResult = validator.Validate(model);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);
            }

            return responseList;
        }

        public static ListStringResponseModel ValidateCodesArrayModel(CodesArrayModel model)
        {
            MatrixArrayCodesValidationService validator = new MatrixArrayCodesValidationService();
            ListStringResponseModel responseList = new ListStringResponseModel();

            ValidationResult validationResult = validator.Validate(model);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);
            }

            return responseList;
        }
    }
}

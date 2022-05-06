using DataAbstraction.Models;
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

        public static ListStringResponseModel ValidateMatrixClientCodeModel(MatrixClientCodeModel model)
        {
            CDPortfolioValidationService validator = new CDPortfolioValidationService();
            var responseList = new ListStringResponseModel();

            ValidationResult validationResult = validator.Validate(model);

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
    }
}

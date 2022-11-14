using DataAbstraction.Models;
using DataAbstraction.Models.DataBaseModels;
using DataAbstraction.Models.Responses;
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

            if (model.MatrixClientPortfolio.Contains("RF"))// наверно лишнее но пусть пока будет. Rf коды проверяются в Fluent validator
            {
                responseList.IsSuccess = false;
                responseList.Messages.Add("RF portfolio not allowed in SPOT BRL");
            }

            return responseList;
        }

        public static ListStringResponseModel ValidateMatrixSpotClientCodeModel(MatrixClientPortfolioModel model)
        {
            ClientCodeSpotMatrixMsMoFxRsValidator validator = new ClientCodeSpotMatrixMsMoFxRsValidator();
            var responseList = new ListStringResponseModel();

            ValidationResult validationResult = validator.Validate(model.MatrixClientPortfolio);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);
            }

            return responseList;
        }

        public static ListStringResponseModel ValidateDealerLibrary(string library)
        {
            var response = new ListStringResponseModel();

            if (!DealerLibrarys.DealerLibrary.Contains(library))
            {
                response.Messages.Add($"Error! '{library}' is not recognised. Please use existind lib name.");
                response.IsSuccess = false;
            }

            return response;
        }

        public static ListStringResponseModel ValidateQCodeAndListOfComplexProductsTestsModel(QCodeAndListOfComplexProductsTestsModel[] model)
        {
            QCodeAndListOfComplexProductsTestsValidationService validator = new QCodeAndListOfComplexProductsTestsValidationService();
            ListStringResponseModel responseList = new ListStringResponseModel();

            ValidationResult validationResult = validator.Validate(model);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);
            }

            return responseList;
        }

        public static ListStringResponseModel ValidateMixedClientCodesArray(IEnumerable<string> code)
        {
            var responseList = new ListStringResponseModel();

            foreach (string str in code)
            {
                if (str.StartsWith("C0"))
                {
                    ClientCodeFortsC0MatrixValidator validator = new ClientCodeFortsC0MatrixValidator();
                    ValidationResult validationResult = validator.Validate(str);
                    if (!validationResult.IsValid)
                    {
                        responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);
                    }
                }
                else if (str.StartsWith("B") || str.StartsWith("A"))
                {
                    ClientCodeSpotMatrixMsMoFxRsCdValidator validator = new ClientCodeSpotMatrixMsMoFxRsCdValidator();
                    ValidationResult validationResult = validator.Validate(str);
                    if (!validationResult.IsValid)
                    {
                        responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);
                    }
                }
                else
                {
                    responseList.IsSuccess = false;
                    responseList.Messages.Add($"VC100 '{str}' is not in expected formats 'BP12345-XX-01' or 'C0xxxxx'");
                }
            }

            return responseList;
        }

        public static BoolResponse ValidateMatrixSpotClientCodesArray(IEnumerable<string> code)
        {
            var response = new BoolResponse();
            var responseList = new ListStringResponseModel();

            foreach (string str in code)
            {
                ClientCodeSpotMatrixMsMoFxRsCdValidator validator = new ClientCodeSpotMatrixMsMoFxRsCdValidator();
                ValidationResult validationResult = validator.Validate(str);
                if (!validationResult.IsValid)
                {
                    responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);
                }
            }

            response.IsSuccess = responseList.IsSuccess;
            response.Messages = responseList.Messages;

            return response;
        }

        public static ListStringResponseModel ValidateNewMNPClientModel(NewMNPClientModel model)
        {
            NewMNPClientValidationService validator = new NewMNPClientValidationService();
            ListStringResponseModel responseList = new ListStringResponseModel();

            ValidationResult validationResult = validator.Validate(model);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);
            }

            return responseList;
        }

        public static ListStringResponseModel ValidateMatrixClientAccountModel(MatrixClientAccountModel model)
        {
            MatrixClientAccountValidator validator = new MatrixClientAccountValidator();
            var responseList = new ListStringResponseModel();

            ValidationResult validationResult = validator.Validate(model.MatrixClientAccount);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);
            }

            return responseList;
        }

        public static ListStringResponseModel ValidateMatrixCDClientCodeModel(MatrixClientPortfolioModel model)
        {
            ClientCodeSpotMatrixCdValidator validator = new ClientCodeSpotMatrixCdValidator();
            var responseList = new ListStringResponseModel();

            ValidationResult validationResult = validator.Validate(model.MatrixClientPortfolio);

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

        public static ListStringResponseModel ValidateMatrixPortfolioAndUidModel(MatrixPortfolioAndUidModel model)
        {
            MatrixPortfolioAndUidModelValidationService validator = new MatrixPortfolioAndUidModelValidationService();
            ListStringResponseModel responseList = new ListStringResponseModel();

            ValidationResult validationResult = validator.Validate(model);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);
            }

            return responseList;
        }

        public static ListStringResponseModel ValidateFortsCodeAndUidModel(FortsCodeAndUidModel model)
        {
            FortsCodeAndUidModelValidationService validator = new FortsCodeAndUidModelValidationService();
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

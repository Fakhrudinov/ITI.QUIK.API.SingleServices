using DataAbstraction.Interfaces;
using DataAbstraction.Models;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using DataValidationService;
using CommonServices;

namespace ITI.QUIKAPI.MicroServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuikQAdminSpotApiController : ControllerBase
    {
        private ISpotBrlService _qService;
        private ILogger<QuikQAdminSpotApiController> _logger;

        public QuikQAdminSpotApiController(ISpotBrlService qService, ILogger<QuikQAdminSpotApiController> logger)
        {
            _qService = qService;
            _logger = logger;
        }

        [HttpGet("GetLogin")]
        public IActionResult Login()
        {
            _logger.LogInformation("HttpGet GetLogin Call");
            string result = _qService.GetLogin();
            _logger.LogInformation("HttpGet GetLogin result = " + result);
            
            var response = new StringResponceModel();
            response.Message = result;
            return Ok(response);
        }

        [HttpGet("CheckConnections/SpotApi")]
        public IActionResult CheckConnection()
        {
            _logger.LogInformation("HttpGet CheckConnections/SpotApi Call");

            var response = new StringResponceModel();
            var result = _qService.CheckConnection();            

            if (result == null)
            {
                _logger.LogWarning("HttpGet CheckConnections Result = No answer received from QUIK BRL MC0138200000");
                response.IsSuccess = false;
                response.Message = "No answer received from QUIK BRL MC0138200000";
                return BadRequest(response);
            }
            else if (result.Equals("OK"))
            {
                _logger.LogInformation("HttpGet CheckConnections Result = OK");

                response.Message = "OK";
                return Ok(response);
            }
            else
            {
                _logger.LogWarning("HttpGet CheckConnections Result = " + result);
                response.IsSuccess = false;
                response.Message = "HttpGet CheckConnections Result = " + result;
                return BadRequest(response);
            } 
        }

        [HttpPost("AddMatrixClientPortfolioTo/KomissiiTemplate/CD_portfolio/{portfolio}")]
        public IActionResult AddClientPortfolioToKomissiiCDportfolio(string portfolio)
        {
            _logger.LogInformation("Httppost AddMatrixClientPortfolioTo/KomissiiTemplate/CD_portfolio Call, " + portfolio);

            CDPortfolioValidationService validator = new CDPortfolioValidationService();
            var responseList = new ListStringResponseModel();

            ValidationResult validationResult = validator.Validate(portfolio);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);

                string errors = SetResponseFromValidationResult.GetErrorsCodeFromValidationResult(validationResult);
                _logger.LogWarning("Httppost AddMatrixClientPortfolioTo/KomissiiTemplate/CD_portfolio Failed with " + errors);
                return BadRequest(responseList);
            }

            string quikportfolio = PortfoliosConvertingService.GetCdPortfolio(portfolio);

            string result = _qService.AddClientPortfolioToKomissiiCDportfolio(quikportfolio);

            var response = new StringResponceModel();
            response.Message = result;

            if (result.Equals("OK"))
            {
                _logger.LogInformation("Httppost AddMatrixClientPortfolioTo/KomissiiTemplate/CD_portfolio Result = OK");

                return Ok(response);
            }
            else
            {
                _logger.LogWarning("Httppost AddMatrixClientPortfolioTo/KomissiiTemplate/CD_portfolio Failed with " + result);
                response.IsSuccess = false;                
                return BadRequest(response);
            }
        }

        [HttpPost("AddMatrixClientPortfolioTo/LeverageTemplate/CD_portfolio/{portfolio}")]
        public IActionResult AddClientPortfolioToLeverageCDportfolio(string portfolio)
        {
            _logger.LogInformation("Httppost AddMatrixClientPortfolioTo/LeverageTemplate/CD_portfolio Call, " + portfolio);

            CDPortfolioValidationService validator = new CDPortfolioValidationService();
            var responseList = new ListStringResponseModel();

            ValidationResult validationResult = validator.Validate(portfolio);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);

                string errors = SetResponseFromValidationResult.GetErrorsCodeFromValidationResult(validationResult);
                _logger.LogWarning("Httppost AddMatrixClientPortfolioTo/LeverageTemplate/CD_portfolio Failed with " + errors);
                return BadRequest(responseList);
            }

            string quikportfolio = PortfoliosConvertingService.GetCdPortfolio(portfolio);

            string result = _qService.AddClientPortfolioToLeverageCDportfolio(quikportfolio);

            var response = new StringResponceModel();
            response.Message = result;

            if (result.Equals("OK"))
            {
                _logger.LogInformation("Httppost AddMatrixClientPortfolioTo/LeverageTemplate/CD_portfolio Result = OK");

                return Ok(response);
            }
            else
            {
                _logger.LogWarning("Httppost AddMatrixClientPortfolioTo/LeverageTemplate/CD_portfolio Failed with " + result);
                response.IsSuccess = false;
                return BadRequest(response);
            }
        }

        [HttpPost("AddMatrixClientPortfolioTo/KomissiiTemplate")]
        public IActionResult AddClientPortfolioToKomissiiTemplate([FromBody] TemplateAndCodeModel model)
        {
            _logger.LogInformation($"Httppost AddMatrixClientPortfolioTo/KomissiiTemplate Call {model.Template} {model.ClientCode}");

            TemplateAndMatrixCodeModelValidationService validator = new TemplateAndMatrixCodeModelValidationService();
            var responseList = new ListStringResponseModel();

            ValidationResult validationResult = validator.Validate(model);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);

                string errors = SetResponseFromValidationResult.GetErrorsCodeFromValidationResult(validationResult);
                _logger.LogWarning("HttpPost AddMatrixClientPortfolioTo/KomissiiTemplate Failed with " + errors);
                return BadRequest(responseList);
            }

            string quikportfolio = PortfoliosConvertingService.GetSpotPortfolio(model.ClientCode);
            var response = new StringResponceModel();

            if (model.ClientCode.Contains("CD"))
            {
                quikportfolio = PortfoliosConvertingService.GetCdPortfolio(model.ClientCode);
            }
            if (model.ClientCode.Contains("RF"))
            {
                _logger.LogWarning("Httppost AddMatrixClientPortfolioTo/KomissiiTemplate Failed with Error: RF portfolio not allowed in SPOT BRL");
                response.IsSuccess = false;
                response.Message = "RF portfolio not allowed in SPOT BRL";
                return BadRequest(response);
            }

            string result = _qService.AddClientPortfolioToKomissiiTemplate(model.Template, quikportfolio);

            response.Message = result;

            if (result.Equals("OK"))
            {
                _logger.LogInformation("Httppost AddMatrixClientPortfolioTo/KomissiiTemplate Result = OK");

                return Ok(response);
            }
            else
            {
                _logger.LogWarning("Httppost AddMatrixClientPortfolioTo/KomissiiTemplate Failed with " + result);
                response.IsSuccess = false;
                return BadRequest(response);
            }
        }

        [HttpPost("AddMatrixClientPortfolioTo/LeverageTemplate")]
        public IActionResult AddClientPortfolioToLeverageTemplate([FromBody] TemplateAndCodeModel model)
        {
            _logger.LogInformation($"HttpPost AddMatrixClientPortfolioTo/LeverageTemplate Call {model.Template} {model.ClientCode}");

            TemplateAndMatrixCodeModelValidationService validator = new TemplateAndMatrixCodeModelValidationService();
            var responseList = new ListStringResponseModel();

            ValidationResult validationResult = validator.Validate(model);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);

                string errors = SetResponseFromValidationResult.GetErrorsCodeFromValidationResult(validationResult);
                _logger.LogWarning("HttpPost AddMatrixClientPortfolioTo/LeverageTemplate Failed with " + errors);
                return BadRequest(responseList);
            }

            string quikportfolio = PortfoliosConvertingService.GetSpotPortfolio(model.ClientCode);
            var response = new StringResponceModel();

            if (model.ClientCode.Contains("CD"))
            {
                quikportfolio = PortfoliosConvertingService.GetCdPortfolio(model.ClientCode);
            }
            if (model.ClientCode.Contains("RF"))
            {
                _logger.LogWarning("Httppost AddMatrixClientPortfolioTo/LeverageTemplate Failed with Error: RF portfolio not allowed in SPOT BRL");
                response.IsSuccess = false;
                response.Message = "RF portfolio not allowed in SPOT BRL";
                return BadRequest(response);
            }

            string result = _qService.AddClientPortfolioToLeverageTemplate(model.Template, quikportfolio);

            response.Message = result;

            if (result.Equals("OK"))
            {
                _logger.LogInformation("Httppost AddMatrixClientPortfolioTo/LeverageTemplate Result = OK");

                return Ok(response);
            }
            else
            {
                _logger.LogWarning("Httppost AddMatrixClientPortfolioTo/LeverageTemplate Failed with " + result);
                response.IsSuccess = false;
                return BadRequest(response);
            }
        }

        [HttpGet("GetAllTemplates/PoKomisii")]
        public IActionResult GetAllTemplatesPoKomissii()
        {
            _logger.LogInformation("HttpGet GetAllTemplates/PoKomisii Call");

            string [] result = _qService.GetAllTemplatesPoKomissii();

            return Ok(result);
        }

        [HttpGet("GetAllTemplates/PoPlechu")]
        public IActionResult GetAllTemplatesPoPlechu()
        {
            _logger.LogInformation("HttpGet GetAllTemplates/PoPlechu Call");

            string[] result = _qService.GetAllTemplatesPoPlechu();

            return Ok(result);
        }

        [HttpGet("GetAllClientsFromTemplate/PoKomissii/{templateName}")]
        public IActionResult GetAllClientsFromTemplatePoKomissii(string templateName)
        {
            _logger.LogInformation("HttpGet GetAllClientsFromTemplate/PoKomissii Call " + templateName);

            string[] result = _qService.GetAllClientsFromTemplatePoKomissii(templateName);

            return Ok(result);
        }

        [HttpGet("GetAllClientsFromTemplate/PoPlechu/{templateName}")]
        public IActionResult GetAllClientsFromTemplatePoPlechu(string templateName)
        {
            _logger.LogInformation("HttpGet GetAllClientsFromTemplate/PoPlechu Call " + templateName);

            string[] result = _qService.GetAllClientsFromTemplatePoPlechu(templateName);

            return Ok(result);
        }

        [HttpDelete("DeleteQuikCodeFromTemplate/PoKomissii")]
        public IActionResult DeleteCodeFromTemplatePoKomissii([FromBody] TemplateAndCodeModel model)
        {
            _logger.LogInformation($"HttpDelete DeleteQuikCodeFromTemplate/PoKomissii Call {model.Template} {model.ClientCode}");

            TemplateAndQuikCodeModelValidationService validator = new TemplateAndQuikCodeModelValidationService();
            var responseList = new ListStringResponseModel();

            ValidationResult validationResult = validator.Validate(model);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);

                string errors = SetResponseFromValidationResult.GetErrorsCodeFromValidationResult(validationResult);
                _logger.LogWarning("HttpDelete DeleteQuikCodeFromTemplate/PoKomissii Failed with " + errors);
                return BadRequest(responseList);
            }

            string result = _qService.DeleteCodeFromTemplatePoKomissii(model);

            return Ok(result);
        }

        [HttpDelete("DeleteQuikCodeFromTemplate/PoPlechu")]
        public IActionResult DeleteCodeFromTemplatePoPlechu([FromBody] TemplateAndCodeModel model)
        {
            _logger.LogInformation($"HttpDelete DeleteQuikCodeFromTemplate/PoPlechu Call {model.Template} {model.ClientCode}");
            TemplateAndQuikCodeModelValidationService validator = new TemplateAndQuikCodeModelValidationService();
            var responseList = new ListStringResponseModel();

            ValidationResult validationResult = validator.Validate(model);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);

                string errors = SetResponseFromValidationResult.GetErrorsCodeFromValidationResult(validationResult);
                _logger.LogWarning("HttpDelete DeleteQuikCodeFromTemplate/PoPlechu Failed with " + errors);
                return BadRequest(responseList);
            }

            string result = _qService.DeleteCodeFromTemplatePoPlechu(model);

            return Ok(result);
        }


        [HttpPut("MoveClientCodeBetweenTemplates/PoKomissii")]
        public IActionResult MoveClientCodeBetweenTemplatesPoKomissii([FromBody] MoveCodeModel moveModel)
        {
            _logger.LogInformation($"HttpPut MoveClientCodeBetweenTemplates/PoKomissii Call {moveModel.FromTemplate} -> {moveModel.ToTemplate} {moveModel.ClientCode}");

            MoveCodeModelValidationService validator = new MoveCodeModelValidationService();
            var responseList = new ListStringResponseModel();

            ValidationResult validationResult = validator.Validate(moveModel);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);

                string errors = SetResponseFromValidationResult.GetErrorsCodeFromValidationResult(validationResult);
                _logger.LogWarning("HttpPut MoveClientCodeBetweenTemplates/PoKomissii Failed with " + errors);
                return BadRequest(responseList);
            }

            string result = _qService.MoveClientCodeBetweenTemplatesPoKomissii(moveModel);
            return Ok(result);
        }

        [HttpPut("MoveClientCodeBetweenTemplates/PoPlechu")]
        public IActionResult MoveClientCodeBetweenTemplatesPoPlechu([FromBody] MoveCodeModel moveModel)
        {
            _logger.LogInformation($"HttpPut MoveClientCodeBetweenTemplates/PoPlechu Call {moveModel.FromTemplate} -> {moveModel.ToTemplate} {moveModel.ClientCode}");

            MoveCodeModelValidationService validator = new MoveCodeModelValidationService();
            var responseList = new ListStringResponseModel();

            ValidationResult validationResult = validator.Validate(moveModel);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);

                string errors = SetResponseFromValidationResult.GetErrorsCodeFromValidationResult(validationResult);
                _logger.LogWarning("HttpPut MoveClientCodeBetweenTemplates/PoPlechu Failed with " + errors);
                return BadRequest(responseList);
            }

            string result = _qService.MoveClientCodeBetweenTemplatesPoPlechu(moveModel);
            return Ok(result);
        }

        [HttpPost("ReplaceAllCodesMatrixInTemplate/PoKomisii")]
        public IActionResult ReplaceAllClientPortfoliosInPoKomisiiTemplate([FromBody] TemplateAndCodesModel model)
        {
            _logger.LogInformation($"Httppost ReplaceAllCodesMatrixInTemplate/PoKomisii Call, {model.Template} with {model.ClientCodes.Length} codes");

            var responseList = new ListStringResponseModel();
            TemplateAndMatrixArrayCodesModelValidationService validator = new TemplateAndMatrixArrayCodesModelValidationService();
            ValidationResult validationResult = validator.Validate(model);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);

                string errors = SetResponseFromValidationResult.GetErrorsCodeFromValidationResult(validationResult);
                _logger.LogWarning("Httppost ReplaceAllCodesMatrixInTemplate/PoKomisii Failed with " + errors);
                return BadRequest(responseList);
            }
            //TemplateAndCodeModel modelSingle = new TemplateAndCodeModel();
            //modelSingle.Template = "ABCDE";//set correct template
            ////проверки
            //foreach (var code in model.ClientCodes)
            //{
            //    if (code.Contains("RF")) //проверка наличия срочного рынка
            //    {
            //        _logger.LogWarning($"Httppost ReplaceAllCodesMatrixInTemplate/PoKomisii Failed with Error: RF portfolio {code} not allowed in SPOT BRL");
            //        responseList.IsSuccess = false;
            //        responseList.Messages.Add($"RF portfolio {code} not allowed in SPOT BRL");
            //    }
            //    else // проверка кода
            //    {
            //        modelSingle.ClientCode = code;
            //        ValidationResult validationCodeResult = validator.Validate(modelSingle);

            //        if (!validationCodeResult.IsValid)
            //        {
            //            responseList.IsSuccess = false;
            //            foreach (ValidationFailure failure in validationCodeResult.Errors)
            //            {
            //                responseList.Messages.Add(failure.ErrorCode + " " + failure.ErrorMessage);
            //            }
            //            _logger.LogWarning("Httppost ReplaceAllCodesMatrixInTemplate/PoKomisii Validation Failed at " + code);
            //        }
            //    }
            //}
            //// проверка шаблона
            //modelSingle.ClientCode = "BP1234-MS-01";//set correct code
            //modelSingle.Template = model.Template;
            //ValidationResult validationTemplResult = validator.Validate(modelSingle);
            //if (!validationTemplResult.IsValid)
            //{
            //    responseList.IsSuccess = false;
            //    foreach (ValidationFailure failure in validationTemplResult.Errors)
            //    {
            //        responseList.Messages.Add(failure.ErrorCode + " " + failure.ErrorMessage);
            //    }

            //    _logger.LogWarning("Httppost ReplaceAllCodesMatrixInTemplate/PoKomisii Validation Failed at template " + model.Template);
            //}
            //if (!responseList.IsSuccess)
            //{
            //    return BadRequest(responseList);
            //}

            // переделаем коды на QUIK формат
            for (int i = 0; i < model.ClientCodes.Length; i++)
            {
                if (model.ClientCodes[i].Contains("CD"))
                {
                    model.ClientCodes[i] = PortfoliosConvertingService.GetCdPortfolio(model.ClientCodes[i]);
                }
                else
                {
                    model.ClientCodes[i] = PortfoliosConvertingService.GetSpotPortfolio(model.ClientCodes[i]);
                }
            }

            string result = _qService.ReplaceAllCodesMatrixInPoKomisiiTemplate(model);

            var response = new StringResponceModel();
            response.Message = result;

            if (result.Equals("OK"))
            {
                _logger.LogInformation("Httppost ReplaceAllCodesMatrixInTemplate/PoKomisii Result = OK");

                return Ok(response);
            }
            else
            {
                _logger.LogWarning("Httppost ReplaceAllCodesMatrixInTemplate/PoKomisii Failed with " + result);
                response.IsSuccess = false;
                return BadRequest(response);
            }
        }

        [HttpPost("ReplaceAllCodesMatrixInTemplate/Leverage")]
        public IActionResult ReplaceAllClientPortfoliosInLeverageTemplate([FromBody] TemplateAndCodesModel model)
        {
            _logger.LogInformation($"Httppost ReplaceAllCodesMatrixInTemplate/Leverage Call, {model.Template} with {model.ClientCodes.Length} codes");
            
            var responseList = new ListStringResponseModel();
            TemplateAndMatrixArrayCodesModelValidationService validator = new TemplateAndMatrixArrayCodesModelValidationService();
            ValidationResult validationResult = validator.Validate(model);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);

                string errors = SetResponseFromValidationResult.GetErrorsCodeFromValidationResult(validationResult);
                _logger.LogWarning("Httppost ReplaceAllCodesMatrixInTemplate/Leverage Failed with " + errors);
                return BadRequest(responseList);
            }

            //TemplateAndCodeModel modelSingle =  new TemplateAndCodeModel();
            //modelSingle.Template = "ABCDE";//set correct template
            ////проверки
            //foreach (var code in model.ClientCodes)
            //{
            //    if (code.Contains("RF")) //проверка наличия срочного рынка
            //    {
            //        _logger.LogWarning($"Httppost ReplaceAllCodesMatrixInTemplate/Leverage Failed with Error: RF portfolio {code} not allowed in SPOT BRL");
            //        responseList.IsSuccess = false;
            //        responseList.Messages.Add($"RF portfolio {code} not allowed in SPOT BRL");
            //    }
            //    else // проверка кода
            //    {
            //        modelSingle.ClientCode = code;
            //        ValidationResult validationCodeResult = validator.Validate(modelSingle);
            //        if (!validationCodeResult.IsValid)
            //        {
            //            responseList.IsSuccess = false;
            //            foreach (ValidationFailure failure in validationCodeResult.Errors)
            //            {
            //                responseList.Messages.Add(failure.ErrorCode + " " + failure.ErrorMessage);
            //            }
            //            _logger.LogWarning("Httppost ReplaceAllCodesMatrixInTemplate/Leverage Validation Failed at " + code);
            //        }
            //    }
            //}
            //// проверка шаблона
            //modelSingle.ClientCode = "BP1234-MS-01";//set correct code
            //modelSingle.Template = model.Template;
            //ValidationResult validationTemplResult = validator.Validate(modelSingle);
            //if (!validationTemplResult.IsValid)
            //{
            //    responseList.IsSuccess = false;
            //    foreach (ValidationFailure failure in validationTemplResult.Errors)
            //    {
            //        responseList.Messages.Add(failure.ErrorCode + " " + failure.ErrorMessage);
            //    }
            //    _logger.LogWarning("Httppost ReplaceAllCodesMatrixInTemplate/Leverage Validation Failed at template " + model.Template);
            //}
            //if (!responseList.IsSuccess)
            //{
            //    return BadRequest(responseList);
            //}

            // переделаем коды на QUIK формат
            for (int i = 0; i < model.ClientCodes.Length; i++)
            {    
                if (model.ClientCodes[i].Contains("CD"))
                {
                    model.ClientCodes[i] = PortfoliosConvertingService.GetCdPortfolio(model.ClientCodes[i]);
                }
                else
                {
                    model.ClientCodes[i] = PortfoliosConvertingService.GetSpotPortfolio(model.ClientCodes[i]);
                }
            }

            string result = _qService.ReplaceAllCodesMatrixInLeverageTemplate(model);

            var response = new StringResponceModel();
            response.Message = result;

            if (result.Equals("OK"))
            {
                _logger.LogInformation("Httppost ReplaceAllCodesMatrixInTemplate/Leverage Result = OK");

                return Ok(response);
            }
            else
            {
                _logger.LogWarning("Httppost ReplaceAllCodesMatrixInTemplate/Leverage Failed with " + result);
                response.IsSuccess = false;
                return BadRequest(response);
            }
        }
    }
}

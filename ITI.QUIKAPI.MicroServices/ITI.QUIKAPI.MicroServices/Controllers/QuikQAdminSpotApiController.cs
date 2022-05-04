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
            
            var result = _qService.CheckConnection();

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("AddMatrixClientPortfolioTo/KomissiiTemplate/CD_portfolio")]
        public IActionResult AddClientPortfolioToKomissiiCDportfolio([FromBody] MatrixClientCodeModel model)
        {
            _logger.LogInformation("Httppost AddMatrixClientPortfolioTo/KomissiiTemplate/CD_portfolio Call, " + model.MatrixClientCode);

            CDPortfolioValidationService validator = new CDPortfolioValidationService();
            var responseList = new ListStringResponseModel();

            ValidationResult validationResult = validator.Validate(model);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);

                string errors = SetResponseFromValidationResult.GetErrorsCodeFromValidationResult(validationResult);
                _logger.LogWarning("Httppost AddMatrixClientPortfolioTo/KomissiiTemplate/CD_portfolio Failed with " + errors);
                return BadRequest(responseList);
            }

            string quikportfolio = PortfoliosConvertingService.GetCdPortfolio(model.MatrixClientCode);

            var result = _qService.AddClientPortfolioToKomissiiCDportfolio(quikportfolio);
            
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("AddMatrixClientPortfolioTo/LeverageTemplate/CD_portfolio")]
        public IActionResult AddClientPortfolioToLeverageCDportfolio([FromBody] MatrixClientCodeModel model)
        {
            _logger.LogInformation("Httppost AddMatrixClientPortfolioTo/LeverageTemplate/CD_portfolio Call, " + model.MatrixClientCode);

            CDPortfolioValidationService validator = new CDPortfolioValidationService();
            var responseList = new ListStringResponseModel();

            ValidationResult validationResult = validator.Validate(model);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);

                string errors = SetResponseFromValidationResult.GetErrorsCodeFromValidationResult(validationResult);
                _logger.LogWarning("Httppost AddMatrixClientPortfolioTo/LeverageTemplate/CD_portfolio Failed with " + errors);
                return BadRequest(responseList);
            }

            string quikportfolio = PortfoliosConvertingService.GetCdPortfolio(model.MatrixClientCode);

            var result = _qService.AddClientPortfolioToLeverageCDportfolio(quikportfolio);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
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

            var result = _qService.AddClientPortfolioToKomissiiTemplate(model.Template, quikportfolio);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
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

            var result = _qService.AddClientPortfolioToLeverageTemplate(model.Template, quikportfolio);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }

            //response.Message = result;

            //if (result.Equals("OK"))
            //{
            //    _logger.LogInformation("Httppost AddMatrixClientPortfolioTo/LeverageTemplate Result = OK");

            //    return Ok(response);
            //}
            //else
            //{
            //    _logger.LogWarning("Httppost AddMatrixClientPortfolioTo/LeverageTemplate Failed with " + result);
            //    response.IsSuccess = false;
            //    return BadRequest(response);
            //}
        }

        [HttpGet("GetAllTemplates/PoKomisii")]
        public IActionResult GetAllTemplatesPoKomissii()
        {
            _logger.LogInformation("HttpGet GetAllTemplates/PoKomisii Call");

            var result = _qService.GetAllTemplatesPoKomissii();

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("GetAllTemplates/PoPlechu")]
        public IActionResult GetAllTemplatesPoPlechu()
        {
            _logger.LogInformation("HttpGet GetAllTemplates/PoPlechu Call");

            var result = _qService.GetAllTemplatesPoPlechu();

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("GetAllClientsFromTemplate/PoKomissii/{templateName}")]
        public IActionResult GetAllClientsFromTemplatePoKomissii(string templateName)
        {
            _logger.LogInformation("HttpGet GetAllClientsFromTemplate/PoKomissii Call " + templateName);

            var result = _qService.GetAllClientsFromTemplatePoKomissii(templateName);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("GetAllClientsFromTemplate/PoPlechu/{templateName}")]
        public IActionResult GetAllClientsFromTemplatePoPlechu(string templateName)
        {
            _logger.LogInformation("HttpGet GetAllClientsFromTemplate/PoPlechu Call " + templateName);

            var result = _qService.GetAllClientsFromTemplatePoPlechu(templateName);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete("DeleteQuikCodeFromTemplate/PoKomissii")]
        public IActionResult DeleteCodeFromTemplatePoKomissii([FromBody] TemplateAndQuikCodeModel model)
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

            var result = _qService.DeleteCodeFromTemplatePoKomissii(model);

            return Ok(result);
        }

        [HttpDelete("DeleteQuikCodeFromTemplate/PoPlechu")]
        public IActionResult DeleteCodeFromTemplatePoPlechu([FromBody] TemplateAndQuikCodeModel model)
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

            var result = _qService.DeleteCodeFromTemplatePoPlechu(model);

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

            var result = _qService.MoveClientCodeBetweenTemplatesPoKomissii(moveModel);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
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

            var result = _qService.MoveClientCodeBetweenTemplatesPoPlechu(moveModel);
            
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
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

            // переделаем коды на QUIK формат
            for (int i = 0; i < model.ClientCodes.Length; i++)
            {
                if (model.ClientCodes[i].MatrixClientCode.Contains("CD"))
                {
                    model.ClientCodes[i].MatrixClientCode = PortfoliosConvertingService.GetCdPortfolio(model.ClientCodes[i].MatrixClientCode);
                }
                else
                {
                    model.ClientCodes[i].MatrixClientCode = PortfoliosConvertingService.GetSpotPortfolio(model.ClientCodes[i].MatrixClientCode);
                }
            }

            var result = _qService.ReplaceAllCodesMatrixInPoKomisiiTemplate(model);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
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

            // переделаем коды на QUIK формат
            for (int i = 0; i < model.ClientCodes.Length; i++)
            {    
                if (model.ClientCodes[i].MatrixClientCode.Contains("CD"))
                {
                    model.ClientCodes[i].MatrixClientCode = PortfoliosConvertingService.GetCdPortfolio(model.ClientCodes[i].MatrixClientCode);
                }
                else
                {
                    model.ClientCodes[i].MatrixClientCode = PortfoliosConvertingService.GetSpotPortfolio(model.ClientCodes[i].MatrixClientCode);
                }
            }

            var result = _qService.ReplaceAllCodesMatrixInLeverageTemplate(model);
            
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}

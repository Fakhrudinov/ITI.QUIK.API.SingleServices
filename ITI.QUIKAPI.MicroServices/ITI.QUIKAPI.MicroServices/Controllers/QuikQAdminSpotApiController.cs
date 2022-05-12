using DataAbstraction.Interfaces;
using DataAbstraction.Models;
using Microsoft.AspNetCore.Mvc;
using DataValidationService;

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

            _logger.LogInformation($"HttpGet CheckConnections/SpotApi result OK={result.IsSuccess}");
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

            ListStringResponseModel result = ValidateModel.ValidateMatrixCDClientCodeModel(model);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"Httppost AddMatrixClientPortfolioTo/KomissiiTemplate/CD_portfolio Error: {result.Messages[0]}");
                return BadRequest(result);
            }

            result = _qService.AddClientPortfolioToTemplate(true, "CD_portfolio", model.MatrixClientCode);

            _logger.LogInformation($"Httppost AddMatrixClientPortfolioTo/KomissiiTemplate/CD_portfolio result isOK={result.IsSuccess}");
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpPost("AddMatrixClientPortfolioTo/PoPlechuTemplate/CD_portfolio")]
        public IActionResult AddClientPortfolioToPoPlechuCDportfolio([FromBody] MatrixClientCodeModel model)
        {
            _logger.LogInformation("Httppost AddMatrixClientPortfolioTo/PoPlechuTemplate/CD_portfolio Call, " + model.MatrixClientCode);

            ListStringResponseModel result = ValidateModel.ValidateMatrixCDClientCodeModel(model);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"Httppost AddMatrixClientPortfolioTo/PoPlechuTemplate/CD_portfolio Error: {result.Messages[0]}");
                return BadRequest(result);
            }

            result = _qService.AddClientPortfolioToTemplate(false, "CD_portfolio", model.MatrixClientCode);

            _logger.LogInformation($"Httppost AddMatrixClientPortfolioTo/PoPlechuTemplate/CD_portfolio result isOK={result.IsSuccess}");
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
        public IActionResult AddClientPortfolioToKomissiiTemplate([FromBody] TemplateAndMatrixCodeModel model)
        {
            _logger.LogInformation($"Httppost AddMatrixClientPortfolioTo/KomissiiTemplate Call {model.Template} {model.ClientCode}");

            ListStringResponseModel result = ValidateModel.ValidateTemplateAndMatrixCodeModel(model);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"HttpPost AddMatrixClientPortfolioTo/KomissiiTemplate Error: {result.Messages[0]}");
                return BadRequest(result);
            }

            //проверим на наличие этого шаблона
            ListStringResponseModel isTemplateExist = _qService.GetList(true, true, "");
            if (!isTemplateExist.Messages.Contains(model.Template))
            {
                result.IsSuccess = false;
                result.Messages.Add($"Httppost AddMatrixClientPortfolioTo/KomissiiTemplate Failed: Template {model.Template} not found");

                return BadRequest(result);
            }

            result = _qService.AddClientPortfolioToTemplate(true, model.Template, model.ClientCode);

            _logger.LogInformation($"Httppost AddMatrixClientPortfolioTo/KomissiiTemplate result isOK={result.IsSuccess}");
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("AddMatrixClientPortfolioTo/PoPlechuTemplate")]
        public IActionResult AddClientPortfolioToPoPlechuTemplate([FromBody] TemplateAndMatrixCodeModel model)
        {
            _logger.LogInformation($"HttpPost AddMatrixClientPortfolioTo/PoPlechuTemplate Call {model.Template} {model.ClientCode}");

            ListStringResponseModel result = ValidateModel.ValidateTemplateAndMatrixCodeModel(model);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"HttpPost AddMatrixClientPortfolioTo/PoPlechuTemplate Error: {result.Messages[0]}");
                return BadRequest(result);
            }

            //проверим на наличие этого шаблона
            ListStringResponseModel isTemplateExist = _qService.GetList(true, false, "");
            if (!isTemplateExist.Messages.Contains(model.Template))
            {
                result.IsSuccess = false;
                result.Messages.Add($"Httppost AddMatrixClientPortfolioTo/KomissiiTemplate Failed: Template {model.Template} not found");

                return BadRequest(result);
            }

            result = _qService.AddClientPortfolioToTemplate(false, model.Template, model.ClientCode);

            _logger.LogInformation($"Httppost AddMatrixClientPortfolioTo/PoPlechuTemplate result isOK={result.IsSuccess}");
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }


        [HttpGet("GetAllTemplates/PoKomisii")]
        public IActionResult GetAllTemplatesPoKomissii()
        {
            _logger.LogInformation("HttpGet GetAllTemplates/PoKomisii Call");

            var result = _qService.GetList(true, true, "");

            _logger.LogInformation($"HttpGet GetAllTemplates/PoKomisii result isOK={result.IsSuccess}");
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

            var result = _qService.GetList(true, false, "");

            _logger.LogInformation($"HttpGet GetAllTemplates/PoPlechu result isOK={result.IsSuccess}");
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

            //проверим корректность входных данных
            ListStringResponseModel result = ValidateModel.ValidateTemplateName(templateName);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"HttpGet GetAllClientsFromTemplate/PoKomissii Error: {result.Messages[0]}");
                return BadRequest(result);
            }

            result = _qService.GetList(false, true, templateName);

            _logger.LogInformation($"HttpGet GetAllClientsFromTemplate/PoKomissii result isOK={result.IsSuccess}");
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

            //проверим корректность входных данных
            ListStringResponseModel result = ValidateModel.ValidateTemplateName(templateName);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"HttpGet GetAllClientsFromTemplate/PoPlechu Error: {result.Messages[0]}");
                return BadRequest(result);
            }

            result = _qService.GetList(false, false, templateName);

            _logger.LogInformation($"HttpGet  GetAllClientsFromTemplate/PoPlechu result isOK={result.IsSuccess}");
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }


        [HttpDelete("Delete/QuikCode/FromTemplate/PoKomissii")]
        public IActionResult DeleteQuikCodeFromTemplatePoKomissii([FromBody] TemplateAndQuikCodeModel model)
        {
            _logger.LogInformation($"HttpDelete DeleteQuikCodeFromTemplate/PoKomissii Call {model.Template} {model.ClientCode}");

            ListStringResponseModel result = ValidateModel.ValidateTemplateAndQuikCodeModel(model);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"HttpDelete DeleteQuikCodeFromTemplate/PoKomissii  Error: {result.Messages[0]}");
                return BadRequest(result);
            }

            result = _qService.DeleteCodeFromTemplate(true, model.Template, model.ClientCode, false);

            _logger.LogInformation($"HttpDelete DeleteQuikCodeFromTemplate/PoKomissii result isOK={result.IsSuccess}");
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete("Delete/MatrixCode/FromTemplate/PoKomissii")]
        public IActionResult DeleteMatrixCodeFromTemplatePoKomissii([FromBody] TemplateAndMatrixCodeModel model)
        {
            _logger.LogInformation($"HttpDelete DeleteMatrixCodeFromTemplate/PoKomissii Call {model.Template} {model.ClientCode}");

            ListStringResponseModel result = ValidateModel.ValidateTemplateAndMatrixCodeModel(model);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"HttpDelete DeleteMatrixCodeFromTemplate/PoKomissii  Error: {result.Messages[0]}");
                return BadRequest(result);
            }

            result = _qService.DeleteCodeFromTemplate(true, model.Template, model.ClientCode, true);

            _logger.LogInformation($"HttpDelete DeleteMatrixCodeFromTemplate/PoKomissii result isOK={result.IsSuccess}");
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpDelete("Delete/QuikCode/FromTemplate/PoPlechu")]
        public IActionResult DeleteQuikCodeFromTemplatePoPlechu([FromBody] TemplateAndQuikCodeModel model)
        {
            _logger.LogInformation($"HttpDelete DeleteQuikCodeFromTemplate/PoPlechu Call {model.Template} {model.ClientCode}");

            ListStringResponseModel result = ValidateModel.ValidateTemplateAndQuikCodeModel(model);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"HttpDelete DeleteMatrixCodeFromTemplate/PoPlechu Error: {result.Messages[0]}");
                return BadRequest(result);
            }

            result = _qService.DeleteCodeFromTemplate(false, model.Template, model.ClientCode, false);

            _logger.LogInformation($"HttpDelete DeleteQuikCodeFromTemplate/PoPlechu result isOK={result.IsSuccess}");
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpDelete("Delete/MatrixCode/FromTemplate/PoPlechu")]
        public IActionResult DeleteMatrixCodeFromTemplatePoPlechu([FromBody] TemplateAndMatrixCodeModel model)
        {
            _logger.LogInformation($"HttpDelete DeleteMatrixCodeFromTemplate/PoPlechu Call {model.Template} {model.ClientCode}");

            ListStringResponseModel result = ValidateModel.ValidateTemplateAndMatrixCodeModel(model);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"HttpDelete DeleteMatrixCodeFromTemplate/PoPlechu Error: {result.Messages[0]}");
                return BadRequest(result);
            }

            result = _qService.DeleteCodeFromTemplate(false, model.Template, model.ClientCode, true);

            _logger.LogInformation($"HttpDelete DeleteMatrixCodeFromTemplate/PoPlechu result isOK={result.IsSuccess}");
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }


        [HttpPut("MoveQuikClientCodeBetweenTemplates/PoKomissii")]
        public IActionResult MoveQuikClientCodeBetweenTemplatesPoKomissii([FromBody] MoveQuikCodeModel moveModel)
        {
            _logger.LogInformation($"HttpPut MoveQuikClientCodeBetweenTemplates/PoKomissii Call {moveModel.FromTemplate} -> {moveModel.ToTemplate} {moveModel.ClientCode}");

            ListStringResponseModel result = ValidateModel.ValidateQuikMoveCodeModel(moveModel);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"HttpPut MoveQuikClientCodeBetweenTemplates/PoKomissii Error: {result.Messages[0]}");
                return BadRequest(result);
            }

            result = _qService.MoveQuikClientCodeBetweenTemplates(true, moveModel);

            _logger.LogInformation($"HttpPut MoveQuikClientCodeBetweenTemplates/PoKomissii result isOK={result.IsSuccess}");
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpPut("MoveMatrixClientCodeBetweenTemplates/PoKomissii")]
        public IActionResult MoveMatrixClientCodeBetweenTemplatesPoKomissii([FromBody] MoveMatrixCodeModel moveModel)
        {
            _logger.LogInformation($"HttpPut MoveMatrixClientCodeBetweenTemplates/PoKomissii Call {moveModel.FromTemplate} -> {moveModel.ToTemplate} {moveModel.ClientCode}");

            ListStringResponseModel result = ValidateModel.ValidateMatrixMoveCodeModel(moveModel);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"HttpPut MoveMatrixClientCodeBetweenTemplates/PoKomissii Error: {result.Messages[0]}");
                return BadRequest(result);
            }

            result = _qService.MoveMatrixClientCodeBetweenTemplates(true, moveModel);

            _logger.LogInformation($"HttpPut MoveMatrixClientCodeBetweenTemplates/PoKomissii result isOK={result.IsSuccess}");
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpPut("MoveQuikClientCodeBetweenTemplates/PoPlechu")]
        public IActionResult MoveQuikClientCodeBetweenTemplatesPoPlechu([FromBody] MoveQuikCodeModel moveModel)
        {
            _logger.LogInformation($"HttpPut MoveQuikClientCodeBetweenTemplates/PoPlechu Call {moveModel.FromTemplate} -> {moveModel.ToTemplate} {moveModel.ClientCode}");

            ListStringResponseModel result = ValidateModel.ValidateQuikMoveCodeModel(moveModel);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"HttpPut MoveQuikClientCodeBetweenTemplates/PoPlechu Error: {result.Messages[0]}");
                return BadRequest(result);
            }

            result = _qService.MoveQuikClientCodeBetweenTemplates(false, moveModel);

            _logger.LogInformation($"HttpPut MoveQuikClientCodeBetweenTemplates/PoPlechu result isOK={result.IsSuccess}");
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpPut("MoveMatrixClientCodeBetweenTemplates/PoPlechu")]
        public IActionResult MoveMatrixClientCodeBetweenTemplatesPoPlechu([FromBody] MoveMatrixCodeModel moveModel)
        {
            _logger.LogInformation($"HttpPut MoveMatrixClientCodeBetweenTemplates/PoPlechu Call {moveModel.FromTemplate} -> {moveModel.ToTemplate} {moveModel.ClientCode}");

            ListStringResponseModel result = ValidateModel.ValidateMatrixMoveCodeModel(moveModel);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"HttpPut MoveMatrixClientCodeBetweenTemplates/PoPlechu Error: {result.Messages[0]}");
                return BadRequest(result);
            }

            result = _qService.MoveMatrixClientCodeBetweenTemplates(false, moveModel);

            _logger.LogInformation($"HttpPut MoveMatrixClientCodeBetweenTemplates/PoPlechu result isOK={result.IsSuccess}");
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
        public IActionResult ReplaceAllClientPortfoliosInPoKomisiiTemplate([FromBody] TemplateAndMatrixCodesModel model)
        {
            _logger.LogInformation($"Httppost ReplaceAllCodesMatrixInTemplate/PoKomisii Call, {model.Template} with {model.ClientCodes.Length} codes");

            ListStringResponseModel result = ValidateModel.ValidateTemplateAndMatrixCodesModel(model);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"Httppost ReplaceAllCodesMatrixInTemplate/PoKomisii Error: {result.Messages[0]}");
                return BadRequest(result);
            }

            result = _qService.ReplaceAllCodesInTemplate(true, model);

            _logger.LogInformation($"Httppost ReplaceAllCodesMatrixInTemplate/PoKomisii result isOK={result.IsSuccess}");
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpPost("ReplaceAllCodesMatrixInTemplate/PoPlechu")]
        public IActionResult ReplaceAllClientPortfoliosInPoPlechuTemplate([FromBody] TemplateAndMatrixCodesModel model)
        {
            _logger.LogInformation($"Httppost ReplaceAllClientPortfoliosInTemplate/PoPlechu Call, {model.Template} with {model.ClientCodes.Length} codes");
            
            ListStringResponseModel result = ValidateModel.ValidateTemplateAndMatrixCodesModel(model);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"Httppost ReplaceAllClientPortfoliosInTemplate/PoPlechu Error: {result.Messages[0]}");
                return BadRequest(result);
            }

            result = _qService.ReplaceAllCodesInTemplate(false, model);

            _logger.LogInformation($"Httppost ReplaceAllClientPortfoliosInTemplate/PoPlechu result isOK={result.IsSuccess}");
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

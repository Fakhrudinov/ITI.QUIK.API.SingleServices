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
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpGet GetLogin Call");
            string result = _qService.GetLogin();
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpGet GetLogin result = " + result);
            
            var response = new StringResponceModel();
            response.Message = result;
            return Ok(response);
        }

        [HttpGet("CheckConnections/SpotApi")]
        public IActionResult CheckConnection()
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpGet CheckConnections/SpotApi Call");
            
            var result = _qService.CheckConnection();

            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpGet CheckConnections/SpotApi result OK={result.IsSuccess}");
            
            return Ok(result);
        }

        [HttpPost("AddMatrixClientPortfolioTo/KomissiiTemplate/CD_portfolio")]
        public IActionResult AddClientPortfolioToKomissiiCDportfolio([FromBody] MatrixClientCodeModel model)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Httppost AddMatrixClientPortfolioTo/KomissiiTemplate/CD_portfolio Call, " + model.MatrixClientCode);

            ListStringResponseModel result = ValidateModel.ValidateMatrixCDClientCodeModel(model);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Httppost AddMatrixClientPortfolioTo/KomissiiTemplate/CD_portfolio Error: {result.Messages[0]}");
                return Ok(result);
            }

            result = _qService.AddClientPortfolioToTemplate(true, "CD_portfolio", model.MatrixClientCode);

            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Httppost AddMatrixClientPortfolioTo/KomissiiTemplate/CD_portfolio result isOK={result.IsSuccess}");

            return Ok(result);
        }
        [HttpPost("AddMatrixClientPortfolioTo/PoPlechuTemplate/CD_portfolio")]
        public IActionResult AddClientPortfolioToPoPlechuCDportfolio([FromBody] MatrixClientCodeModel model)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Httppost AddMatrixClientPortfolioTo/PoPlechuTemplate/CD_portfolio Call, " + model.MatrixClientCode);

            ListStringResponseModel result = ValidateModel.ValidateMatrixCDClientCodeModel(model);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Httppost AddMatrixClientPortfolioTo/PoPlechuTemplate/CD_portfolio Error: {result.Messages[0]}");
                return Ok(result);
            }

            result = _qService.AddClientPortfolioToTemplate(false, "CD_portfolio", model.MatrixClientCode);

            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Httppost AddMatrixClientPortfolioTo/PoPlechuTemplate/CD_portfolio result isOK={result.IsSuccess}");
            
            return Ok(result);
        }
        [HttpPost("AddMatrixClientPortfolioTo/KomissiiTemplate")]
        public IActionResult AddClientPortfolioToKomissiiTemplate([FromBody] TemplateAndMatrixCodeModel model)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Httppost AddMatrixClientPortfolioTo/KomissiiTemplate Call {model.Template} {model.ClientCode}");

            ListStringResponseModel result = ValidateModel.ValidateTemplateAndMatrixCodeModel(model);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpPost AddMatrixClientPortfolioTo/KomissiiTemplate Error: {result.Messages[0]}");
                return Ok(result);
            }

            //проверим на наличие этого шаблона
            ListStringResponseModel isTemplateExist = _qService.GetList(true, true, "");
            if (!isTemplateExist.Messages.Contains(model.Template))
            {
                result.IsSuccess = false;
                result.Messages.Add($"Httppost AddMatrixClientPortfolioTo/KomissiiTemplate Failed: Template {model.Template} not found");

                return Ok(result);
            }

            result = _qService.AddClientPortfolioToTemplate(true, model.Template, model.ClientCode);

            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Httppost AddMatrixClientPortfolioTo/KomissiiTemplate result isOK={result.IsSuccess}");
            
            return Ok(result);
        }

        [HttpPost("AddMatrixClientPortfolioTo/PoPlechuTemplate")]
        public IActionResult AddClientPortfolioToPoPlechuTemplate([FromBody] TemplateAndMatrixCodeModel model)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpPost AddMatrixClientPortfolioTo/PoPlechuTemplate Call {model.Template} {model.ClientCode}");

            ListStringResponseModel result = ValidateModel.ValidateTemplateAndMatrixCodeModel(model);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpPost AddMatrixClientPortfolioTo/PoPlechuTemplate Error: {result.Messages[0]}");
                return Ok(result);
            }

            //проверим на наличие этого шаблона
            ListStringResponseModel isTemplateExist = _qService.GetList(true, false, "");
            if (!isTemplateExist.Messages.Contains(model.Template))
            {
                result.IsSuccess = false;
                result.Messages.Add($"Httppost AddMatrixClientPortfolioTo/KomissiiTemplate Failed: Template {model.Template} not found");

                return Ok(result);
            }

            result = _qService.AddClientPortfolioToTemplate(false, model.Template, model.ClientCode);

            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Httppost AddMatrixClientPortfolioTo/PoPlechuTemplate result isOK={result.IsSuccess}");
            
            return Ok(result);
        }


        [HttpGet("GetAllTemplates/PoKomisii")]
        public IActionResult GetAllTemplatesPoKomissii()
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpGet GetAllTemplates/PoKomisii Call");

            var result = _qService.GetList(true, true, "");

            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpGet GetAllTemplates/PoKomisii result isOK={result.IsSuccess}");
            
            return Ok(result);
        }
        [HttpGet("GetAllTemplates/PoPlechu")]
        public IActionResult GetAllTemplatesPoPlechu()
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpGet GetAllTemplates/PoPlechu Call");

            var result = _qService.GetList(true, false, "");

            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpGet GetAllTemplates/PoPlechu result isOK={result.IsSuccess}");
            
            return Ok(result);
        }


        [HttpGet("GetAllClientsFromTemplate/PoKomissii/{templateName}")]
        public IActionResult GetAllClientsFromTemplatePoKomissii(string templateName)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpGet GetAllClientsFromTemplate/PoKomissii Call " + templateName);

            //проверим корректность входных данных
            ListStringResponseModel result = ValidateModel.ValidateTemplateName(templateName);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpGet GetAllClientsFromTemplate/PoKomissii Error: {result.Messages[0]}");
                return Ok(result);
            }

            result = _qService.GetList(false, true, templateName);

            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpGet GetAllClientsFromTemplate/PoKomissii result isOK={result.IsSuccess}");
            
            return Ok(result);
        }
        [HttpGet("GetAllClientsFromTemplate/PoPlechu/{templateName}")]
        public IActionResult GetAllClientsFromTemplatePoPlechu(string templateName)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpGet GetAllClientsFromTemplate/PoPlechu Call " + templateName);

            //проверим корректность входных данных
            ListStringResponseModel result = ValidateModel.ValidateTemplateName(templateName);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpGet GetAllClientsFromTemplate/PoPlechu Error: {result.Messages[0]}");
                return Ok(result);
            }

            result = _qService.GetList(false, false, templateName);

            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpGet  GetAllClientsFromTemplate/PoPlechu result isOK={result.IsSuccess}");
            
            return Ok(result);
        }


        [HttpDelete("Delete/QuikCode/FromTemplate/PoKomissii")]
        public IActionResult DeleteQuikCodeFromTemplatePoKomissii([FromBody] TemplateAndQuikCodeModel model)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpDelete DeleteQuikCodeFromTemplate/PoKomissii Call {model.Template} {model.ClientCode}");

            ListStringResponseModel result = ValidateModel.ValidateTemplateAndQuikCodeModel(model);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpDelete DeleteQuikCodeFromTemplate/PoKomissii  Error: {result.Messages[0]}");
                return Ok(result);
            }

            result = _qService.DeleteCodeFromTemplate(true, model.Template, model.ClientCode, false);

            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpDelete DeleteQuikCodeFromTemplate/PoKomissii result isOK={result.IsSuccess}");
            
            return Ok(result);
        }

        [HttpDelete("Delete/MatrixCode/FromTemplate/PoKomissii")]
        public IActionResult DeleteMatrixCodeFromTemplatePoKomissii([FromBody] TemplateAndMatrixCodeModel model)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpDelete DeleteMatrixCodeFromTemplate/PoKomissii Call {model.Template} {model.ClientCode}");

            ListStringResponseModel result = ValidateModel.ValidateTemplateAndMatrixCodeModel(model);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpDelete DeleteMatrixCodeFromTemplate/PoKomissii  Error: {result.Messages[0]}");
                return Ok(result);
            }

            result = _qService.DeleteCodeFromTemplate(true, model.Template, model.ClientCode, true);

            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpDelete DeleteMatrixCodeFromTemplate/PoKomissii result isOK={result.IsSuccess}");
            
            return Ok(result);
        }
        [HttpDelete("Delete/QuikCode/FromTemplate/PoPlechu")]
        public IActionResult DeleteQuikCodeFromTemplatePoPlechu([FromBody] TemplateAndQuikCodeModel model)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpDelete DeleteQuikCodeFromTemplate/PoPlechu Call {model.Template} {model.ClientCode}");

            ListStringResponseModel result = ValidateModel.ValidateTemplateAndQuikCodeModel(model);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpDelete DeleteMatrixCodeFromTemplate/PoPlechu Error: {result.Messages[0]}");
                return Ok(result);
            }

            result = _qService.DeleteCodeFromTemplate(false, model.Template, model.ClientCode, false);

            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpDelete DeleteQuikCodeFromTemplate/PoPlechu result isOK={result.IsSuccess}");
            
            return Ok(result);
        }
        [HttpDelete("Delete/MatrixCode/FromTemplate/PoPlechu")]
        public IActionResult DeleteMatrixCodeFromTemplatePoPlechu([FromBody] TemplateAndMatrixCodeModel model)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpDelete DeleteMatrixCodeFromTemplate/PoPlechu Call {model.Template} {model.ClientCode}");

            ListStringResponseModel result = ValidateModel.ValidateTemplateAndMatrixCodeModel(model);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpDelete DeleteMatrixCodeFromTemplate/PoPlechu Error: {result.Messages[0]}");
                return Ok(result);
            }

            result = _qService.DeleteCodeFromTemplate(false, model.Template, model.ClientCode, true);

            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpDelete DeleteMatrixCodeFromTemplate/PoPlechu result isOK={result.IsSuccess}");
            
            return Ok(result);
        }


        [HttpPut("MoveQuikClientCodeBetweenTemplates/PoKomissii")]
        public IActionResult MoveQuikClientCodeBetweenTemplatesPoKomissii([FromBody] MoveQuikCodeModel moveModel)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpPut MoveQuikClientCodeBetweenTemplates/PoKomissii Call {moveModel.FromTemplate} -> {moveModel.ToTemplate} {moveModel.ClientCode}");

            ListStringResponseModel result = ValidateModel.ValidateQuikMoveCodeModel(moveModel);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpPut MoveQuikClientCodeBetweenTemplates/PoKomissii Error: {result.Messages[0]}");
                return Ok(result);
            }

            result = _qService.MoveQuikClientCodeBetweenTemplates(true, moveModel);

            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpPut MoveQuikClientCodeBetweenTemplates/PoKomissii result isOK={result.IsSuccess}");
            
            return Ok(result);
        }
        [HttpPut("MoveMatrixClientCodeBetweenTemplates/PoKomissii")]
        public IActionResult MoveMatrixClientCodeBetweenTemplatesPoKomissii([FromBody] MoveMatrixCodeModel moveModel)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpPut MoveMatrixClientCodeBetweenTemplates/PoKomissii Call {moveModel.FromTemplate} -> {moveModel.ToTemplate} {moveModel.ClientCode}");

            ListStringResponseModel result = ValidateModel.ValidateMatrixMoveCodeModel(moveModel);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpPut MoveMatrixClientCodeBetweenTemplates/PoKomissii Error: {result.Messages[0]}");
                return Ok(result);
            }

            result = _qService.MoveMatrixClientCodeBetweenTemplates(true, moveModel);

            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpPut MoveMatrixClientCodeBetweenTemplates/PoKomissii result isOK={result.IsSuccess}");
            
            return Ok(result);
        }
        [HttpPut("MoveQuikClientCodeBetweenTemplates/PoPlechu")]
        public IActionResult MoveQuikClientCodeBetweenTemplatesPoPlechu([FromBody] MoveQuikCodeModel moveModel)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpPut MoveQuikClientCodeBetweenTemplates/PoPlechu Call {moveModel.FromTemplate} -> {moveModel.ToTemplate} {moveModel.ClientCode}");

            ListStringResponseModel result = ValidateModel.ValidateQuikMoveCodeModel(moveModel);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpPut MoveQuikClientCodeBetweenTemplates/PoPlechu Error: {result.Messages[0]}");
                return Ok(result);
            }

            result = _qService.MoveQuikClientCodeBetweenTemplates(false, moveModel);

            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpPut MoveQuikClientCodeBetweenTemplates/PoPlechu result isOK={result.IsSuccess}");
            
            return Ok(result);
        }
        [HttpPut("MoveMatrixClientCodeBetweenTemplates/PoPlechu")]
        public IActionResult MoveMatrixClientCodeBetweenTemplatesPoPlechu([FromBody] MoveMatrixCodeModel moveModel)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpPut MoveMatrixClientCodeBetweenTemplates/PoPlechu Call {moveModel.FromTemplate} -> {moveModel.ToTemplate} {moveModel.ClientCode}");

            ListStringResponseModel result = ValidateModel.ValidateMatrixMoveCodeModel(moveModel);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpPut MoveMatrixClientCodeBetweenTemplates/PoPlechu Error: {result.Messages[0]}");
                return Ok(result);
            }

            result = _qService.MoveMatrixClientCodeBetweenTemplates(false, moveModel);

            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpPut MoveMatrixClientCodeBetweenTemplates/PoPlechu result isOK={result.IsSuccess}");
            
            return Ok(result);
        }


        [HttpPost("ReplaceAllCodesMatrixInTemplate/PoKomisii")]
        public IActionResult ReplaceAllClientPortfoliosInPoKomisiiTemplate([FromBody] TemplateAndMatrixCodesModel model)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Httppost ReplaceAllCodesMatrixInTemplate/PoKomisii Call, {model.Template} with {model.ClientCodes.Length} codes");

            ListStringResponseModel result = ValidateModel.ValidateTemplateAndMatrixCodesModel(model);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Httppost ReplaceAllCodesMatrixInTemplate/PoKomisii Error: {result.Messages[0]}");
                return Ok(result);
            }

            result = _qService.ReplaceAllCodesInTemplate(true, model);

            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Httppost ReplaceAllCodesMatrixInTemplate/PoKomisii result isOK={result.IsSuccess}");
            
            return Ok(result);
        }
        [HttpPost("ReplaceAllCodesMatrixInTemplate/PoPlechu")]
        public IActionResult ReplaceAllClientPortfoliosInPoPlechuTemplate([FromBody] TemplateAndMatrixCodesModel model)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Httppost ReplaceAllClientPortfoliosInTemplate/PoPlechu Call, {model.Template} with {model.ClientCodes.Length} codes");
            
            ListStringResponseModel result = ValidateModel.ValidateTemplateAndMatrixCodesModel(model);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Httppost ReplaceAllClientPortfoliosInTemplate/PoPlechu Error: {result.Messages[0]}");
                return Ok(result);
            }

            result = _qService.ReplaceAllCodesInTemplate(false, model);

            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Httppost ReplaceAllClientPortfoliosInTemplate/PoPlechu result isOK={result.IsSuccess}");
            
            return Ok(result);
        }
    }
}

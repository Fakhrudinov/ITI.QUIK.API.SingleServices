using DataAbstraction.Interfaces;
using DataAbstraction.Models;
using Microsoft.AspNetCore.Mvc;
using DataValidationService;


namespace ITI.QUIKAPI.MicroServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuikQAdminFortsApiController : ControllerBase
    {
        private IFortsBrlService _qService;
        private ILogger<QuikQAdminSpotApiController> _logger;

        public QuikQAdminFortsApiController(IFortsBrlService qService, ILogger<QuikQAdminSpotApiController> logger)
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

        [HttpGet("CheckConnections/FortsApi")]
        public IActionResult CheckConnection()
        {
            _logger.LogInformation("HttpGet CheckConnections/FortsApi Call");

            var result = _qService.CheckConnection();

            _logger.LogInformation($"HttpGet CheckConnections/FortsApi result OK={result.IsSuccess}");

            return Ok(result);
        }


        [HttpGet("GetAllTemplates/PoKomisii")]
        public IActionResult GetAllTemplatesPoKomissii()
        {
            _logger.LogInformation("HttpGet GetAllTemplates/PoKomisii Call");

            var result = _qService.GetList(true, true, "");

            _logger.LogInformation($"HttpGet GetAllTemplates/PoKomisii result isOK={result.IsSuccess}");

            return Ok(result);
        }
        [HttpGet("GetAllTemplates/PoPlechu")]
        public IActionResult GetAllTemplatesPoPlechu()
        {
            _logger.LogInformation("HttpGet GetAllTemplates/PoPlechu Call");

            var result = _qService.GetList(true, false, "");

            _logger.LogInformation($"HttpGet GetAllTemplates/PoPlechu result isOK={result.IsSuccess}");

            return Ok(result);
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
                return Ok(result);
            }

            result = _qService.GetList(false, true, templateName);

            _logger.LogInformation($"HttpGet GetAllClientsFromTemplate/PoKomissii result isOK={result.IsSuccess}");

            return Ok(result);
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
                return Ok(result);
            }

            result = _qService.GetList(false, false, templateName);

            _logger.LogInformation($"HttpGet  GetAllClientsFromTemplate/PoPlechu result isOK={result.IsSuccess}");

            return Ok(result);
        }

        [HttpPost("AddMatrixFortsCode/ToTemplate/PoKomissii")]
        public IActionResult AddMatrixFortsCodeToTemplatePoKomissii([FromBody] TemplateAndFortsCodeModel model)
        {
            _logger.LogInformation($"Httppost AddMatrixFortsCode/ToTemplate/PoKomissii Call {model.Template} {model.ClientCode}");

            //проверим корректность входных данных
            ListStringResponseModel result = ValidateModel.ValidateTemplateAndFortsCodeModel(model);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"HttpPost AddMatrixFortsCode/ToTemplate/PoKomissii Error: {result.Messages[0]}");
                return Ok(result);
            }

            //проверим на наличие этого шаблона
            ListStringResponseModel isTemplateExist = _qService.GetList(true, true, "");
            if (!isTemplateExist.Messages.Contains(model.Template))
            {
                result.IsSuccess = false;
                result.Messages.Add($"Httppost AddMatrixFortsCode/ToTemplate/PoKomissii Failed: Template {model.Template} not found");

                return Ok(result);
            }

            //выполним
            result = _qService.AddFortsCodeToTemplate(true, model.Template, model.ClientCode);

            _logger.LogInformation($"Httppost AddMatrixFortsCode/ToTemplate/PoKomissii result isOK={result.IsSuccess}");

            return Ok(result);
        }

        [HttpPost("AddMatrixFortsCode/ToTemplate/PoPlechu")]
        public IActionResult AddMatrixFortsCodeToTemplatePoPlechu([FromBody] TemplateAndFortsCodeModel model)
        {
            _logger.LogInformation($"Httppost AddMatrixFortsCode/ToTemplate/PoPlechu Call {model.Template} {model.ClientCode}");

            //проверим корректность входных данных
            ListStringResponseModel result = ValidateModel.ValidateTemplateAndFortsCodeModel(model);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"HttpPost AddMatrixFortsCode/ToTemplate/PoPlechu Error: {result.Messages[0]}");
                return Ok(result);
            }

            //проверим на наличие этого шаблона
            ListStringResponseModel isTemplateExist = _qService.GetList(true, false, "");
            if (!isTemplateExist.Messages.Contains(model.Template))
            {
                result.IsSuccess = false;
                result.Messages.Add($"Httppost AddMatrixFortsCode/ToTemplate/PoPlechu Failed: Template {model.Template} not found");

                return Ok(result);
            }

            //выполним
            result = _qService.AddFortsCodeToTemplate(false, model.Template, model.ClientCode);

            _logger.LogInformation($"Httppost AddMatrixFortsCode/ToTemplate/PoPlechu result isOK={result.IsSuccess}");

            return Ok(result);
        }

        [HttpDelete("DeleteMatrixFortsCode/FromTemplate/PoKomissii")]
        public IActionResult DeleteMatrixFortsCoedFromTemplatePoKomissii([FromBody] TemplateAndFortsCodeModel model)
        {
            _logger.LogInformation($"HttpDelete DeleteMatrixFortsCode/FromTemplate/PoKomissii Call {model.Template} {model.ClientCode}");

            //проверим корректность входных данных
            ListStringResponseModel result = ValidateModel.ValidateTemplateAndFortsCodeModel(model);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"HttpDelete DeleteMatrixFortsCode/FromTemplate/PoKomissii Error: {result.Messages[0]}");
                return Ok(result);
            }

            result = _qService.DeleteCodeFromTemplate(true, model.Template, model.ClientCode, true);

            _logger.LogInformation($"HttpDelete DeleteMatrixFortsCode/FromTemplate/PoKomissii result isOK={result.IsSuccess}");

            return Ok(result);
        }
        [HttpDelete("DeleteMatrixFortsCode/FromTemplate/PoPlechu")]
        public IActionResult DeleteMatrixFortsCoedFromTemplatePoPlechu([FromBody] TemplateAndFortsCodeModel model)
        {
            _logger.LogInformation($"HttpDelete DeleteMatrixFortsCode/FromTemplate/PoPlechu Call {model.Template} {model.ClientCode}");

            //проверим корректность входных данных
            ListStringResponseModel result = ValidateModel.ValidateTemplateAndFortsCodeModel(model);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"HttpDelete DeleteMatrixFortsCode/FromTemplate/PoPlechu Error: {result.Messages[0]}");
                return Ok(result);
            }

            result = _qService.DeleteCodeFromTemplate(false, model.Template, model.ClientCode, true);

            _logger.LogInformation($"HttpDelete DeleteMatrixFortsCode/FromTemplate/PoPlechu result isOK={result.IsSuccess}");

            return Ok(result);
        }


        [HttpPut("Move/MatrixFortsCode/BetweenTemplates/PoKomissii")]
        public IActionResult MoveMatrixFortsCodeBetweenTemplatesPoKomissii([FromBody] MoveMatrixFortsCodeModel moveModel)
        {
            _logger.LogInformation($"HttpPut Move/MatrixFortsCode/BetweenTemplates/PoKomissii Call {moveModel.FromTemplate} -> {moveModel.ToTemplate} {moveModel.ClientCode}");

            ListStringResponseModel result = ValidateModel.ValidateMatrixFortsCodeModel(moveModel);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"HttpPut Move/MatrixFortsCode/BetweenTemplates/PoKomissii Error: {result.Messages[0]}");
                return Ok(result);
            }

            result = _qService.MoveMatrixFortsCodeBetweenTemplates(true, moveModel);

            _logger.LogInformation($"HttpPut Move/MatrixFortsCode/BetweenTemplates/PoKomissii result isOK={result.IsSuccess}");

            return Ok(result);
        }
        [HttpPut("Move/MatrixFortsCode/BetweenTemplates/PoPlechu")]
        public IActionResult MoveMatrixFortsCodeBetweenTemplatesPoPlechu([FromBody] MoveMatrixFortsCodeModel moveModel)
        {
            _logger.LogInformation($"HttpPut Move/MatrixFortsCode/BetweenTemplates/PoPlechu Call {moveModel.FromTemplate} -> {moveModel.ToTemplate} {moveModel.ClientCode}");

            ListStringResponseModel result = ValidateModel.ValidateMatrixFortsCodeModel(moveModel);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"HttpPut Move/MatrixFortsCode/BetweenTemplates/PoPlechu Error: {result.Messages[0]}");
                return Ok(result);
            }

            result = _qService.MoveMatrixFortsCodeBetweenTemplates(false, moveModel);

            _logger.LogInformation($"HttpPut Move/MatrixFortsCode/BetweenTemplates/PoPlechu result isOK={result.IsSuccess}");

            return Ok(result);
        }

        [HttpPost("ReplaceAll/MatrixFortsCode/InTemplate/PoKomisii")]
        public IActionResult ReplaceAllMatrixFortsCodeInTemplatePoKomisii([FromBody] TemplateAndMatrixFortsCodesModel model)
        {
            _logger.LogInformation($"Httppost ReplaceAll/MatrixFortsCode/InTemplate/PoKomisii Call, {model.Template} with {model.ClientCodes.Length} codes");

            ListStringResponseModel result = ValidateModel.ValidateTemplateAnMatrixFortsCodesModel(model);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"Httppost ReplaceAll/MatrixFortsCode/InTemplate/PoKomisii Error: {result.Messages[0]}");
                return Ok(result);
            }

            result = _qService.ReplaceAllMatrixFortsCodesInTemplate(true, model);

            _logger.LogInformation($"Httppost ReplaceAll/MatrixFortsCode/InTemplate/PoKomisii result isOK={result.IsSuccess}");

            return Ok(result);
        }
        [HttpPost("ReplaceAll/MatrixFortsCode/InTemplate/PoPlechu")]
        public IActionResult ReplaceAllMatrixFortsCodeInTemplatePoPlechu([FromBody] TemplateAndMatrixFortsCodesModel model)
        {
            _logger.LogInformation($"Httppost ReplaceAll/MatrixFortsCode/InTemplate/PoPlechu Call, {model.Template} with {model.ClientCodes.Length} codes");

            ListStringResponseModel result = ValidateModel.ValidateTemplateAnMatrixFortsCodesModel(model);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"Httppost ReplaceAll/MatrixFortsCode/InTemplate/PoPlechu Error: {result.Messages[0]}");
                return Ok(result);
            }

            result = _qService.ReplaceAllMatrixFortsCodesInTemplate(false, model);

            _logger.LogInformation($"Httppost ReplaceAll/MatrixFortsCode/InTemplate/PoPlechu result isOK={result.IsSuccess}");

            return Ok(result);
        }
    }
}

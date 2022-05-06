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

            var result = _qService.GetList(false, true, templateName);

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

            var result = _qService.GetList(false, false, templateName);

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
    }
}

using DataAbstraction.Interfaces;
using DataAbstraction.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITI.QUIKAPI.MicroServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuikQMonitorController : ControllerBase
    {
        private ILogger<QuikQMonitorController> _logger;
        private IQMonitorService _service;

        public QuikQMonitorController(ILogger<QuikQMonitorController> logger, IQMonitorService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("CheckConnections/QMonitorAPI")]
        public IActionResult CheckConnection()
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpGet CheckConnections/QMonitorAPI Call");

            ListStringResponseModel result = _service.CheckConnections();

            return Ok(result);
        }

        [HttpGet("ReloadDealerLib/{library}")]
        public IActionResult ReloadDealerLib(string library)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpGet ReloadDealerLib/{library} Call");

            //проверим корректность входных данных
            ListStringResponseModel result = DataValidationService.ValidateModel.ValidateDealerLibrary(library);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpGet ReloadDealerLib/{library} Error: {result.Messages[0]}");
                return Ok(result);
            }            

            result = _service.ReloadDealerLib(library);

            return Ok(result);
        }
        [HttpGet("ReloadDealerLib/Spot")]
        public IActionResult ReloadDealerLibSpot()
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpGet ReloadDealerLib/Spot Call");

            ListStringResponseModel result = _service.ReloadDealerLib("MC0138200000");

            return Ok(result);
        }
        [HttpGet("ReloadDealerLib/Forts")]
        public IActionResult ReloadDealerLibForts()
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpGet ReloadDealerLib/Forts Call");

            ListStringResponseModel result = _service.ReloadDealerLib("SPBFUT");

            return Ok(result);
        }
    }
}

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
    }
}

using DataAbstraction.Interfaces;
using DataAbstraction.Models;
using Microsoft.AspNetCore.Http;
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
            _logger.LogInformation("HttpGet CheckConnections/QMonitorAPI Call");

            ListStringResponseModel result = _service.CheckConnections();

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

using Microsoft.AspNetCore.Mvc;

namespace ITI.QUIKAPI.MicroServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthStateController : ControllerBase
    {
        private ILogger<HealthStateController> _logger;

        public HealthStateController(ILogger<HealthStateController> logger)
        {
            _logger = logger;
        }

        [HttpGet("OK")]
        public IActionResult IsOk()
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpGet IsOk Call");
            return Ok("Yes");
        }
    }
}

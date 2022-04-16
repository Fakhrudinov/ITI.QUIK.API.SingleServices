using DataAbstraction.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace ITI.QUIKAPI.MicroServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuikBRLEqComissiiController : ControllerBase
    {
        private ISpotBrlService _repository;
        private ILogger<QuikBRLEqComissiiController> _logger;
        private readonly IConfiguration _configuration;

        public QuikBRLEqComissiiController(ISpotBrlService repository, ILogger<QuikBRLEqComissiiController> logger, IConfiguration configuration)
        {
            _repository = repository;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet("CheckConnections")]
        public async Task<IActionResult> CheckConnection()
        {
            _logger.LogInformation("QuikBRLEqComissiiController HttpGet CheckConnections Call");
            var result = await _repository.CheckConnection();            

            if (result == null)
            {
                _logger.LogWarning("QuikBRLEqComissiiController HttpGet CheckConnections Result = No answer received from QUIK BRL MC0138200000");
                return Problem("No answer received from QUIK BRL MC0138200000");
            }
            else if (result.Equals("OK"))
            {
                _logger.LogInformation("QuikBRLEqComissiiController HttpGet CheckConnections Result = OK");
                return Ok("Connection to MC0138200000 is OK");
            }
            else
            {
                _logger.LogWarning("QuikBRLEqComissiiController HttpGet CheckConnections Result = " + result);
                return Problem(result);
            } 
        }

        [HttpGet("values/GetSecrets")]

        public ActionResult GetSecrets()
        {
            string result;

            string secretKey1 = _configuration["SomeKey"];
            string secretKey2 = _configuration["NewKey"];
            string secretKey3 = _configuration["Features:Monitoring:StartTime"];

            result = secretKey1 + "  /  " + secretKey2 + "  /  " + secretKey3;

            return Ok(result);
        }

    }
}

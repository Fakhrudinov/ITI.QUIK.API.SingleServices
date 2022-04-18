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

        public QuikBRLEqComissiiController(ISpotBrlService repository, ILogger<QuikBRLEqComissiiController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("OK")]
        public async Task<IActionResult> Ok()
        {
            _logger.LogInformation("QuikBRLEqComissiiController HttpGet OK Call");
            return Ok("Yes");
        }

        [HttpGet("login")]
        public async Task<IActionResult> Login()
        {
            _logger.LogInformation("QuikBRLEqComissiiController HttpGet login Call");
            string result = _repository.GetLogin();
            _logger.LogInformation("QuikBRLEqComissiiController HttpGet login result = " + result);
            return Ok(result);
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
                return Ok("Connection to BRL MC0138200000 is OK");
            }
            else
            {
                _logger.LogWarning("QuikBRLEqComissiiController HttpGet CheckConnections Result = " + result);
                return Problem(result);
            } 
        }
    }
}

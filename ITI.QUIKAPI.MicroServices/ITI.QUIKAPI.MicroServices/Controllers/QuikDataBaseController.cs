using DataAbstraction.Interfaces;
using DataAbstraction.Models;
using DataAbstraction.Models.DataBaseModels;
using DataAbstraction.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITI.QUIKAPI.MicroServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuikDataBaseController : ControllerBase
    {
        private ILogger<QuikDataBaseController> _logger;
        private IQuikDataBaseRepository _repository;

        public QuikDataBaseController(ILogger<QuikDataBaseController> logger, IQuikDataBaseRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("CheckConnections/QuikDataBase")]
        public async Task<IActionResult> CheckConnection()
        {
            _logger.LogInformation("HttpGet CheckConnections/QuikDataBase Call");

            ListStringResponseModel result = await _repository.CheckConnections();

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("Get/RegisteredCodes")]
        public async Task<IActionResult> GetRegisteredCodesForts([FromQuery] IEnumerable<string> code)
        {
            _logger.LogInformation("HttpGet Get/RegisteredCodes/Forts Call");

            DataBaseClientCodesResponse result = await _repository.GetRegisteredCodes(code);

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

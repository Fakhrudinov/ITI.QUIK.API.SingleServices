using DataAbstraction.Interfaces;
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
        public IActionResult CheckConnection()
        {
            _logger.LogInformation("HttpGet CheckConnections/QuikDataBase Call");

            var result = _repository.CheckConnections();

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

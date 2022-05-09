using DataAbstraction.Interfaces;
using DataAbstraction.Models;
using Microsoft.AspNetCore.Mvc;
using DataValidationService;


namespace ITI.QUIKAPI.MicroServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuikQAdminEDPApiController : ControllerBase
    {
        private IEdpBrlService _qService;
        private ILogger<QuikQAdminEDPApiController> _logger;

        public QuikQAdminEDPApiController(IEdpBrlService qService, ILogger<QuikQAdminEDPApiController> logger)
        {
            _qService = qService;
            _logger = logger;
        }


        [HttpGet("Get/EDPFortsClientCode/ByMatrixCode")]
        public IActionResult GetEDPFortsClientCodeByMatrixCode([FromQuery] MatrixClientCodeModel model)
        {
            _logger.LogInformation($"HttpGet Get/EDPFortsClientCode/ByMatrixCode/{model.MatrixClientCode}");

            //проверим корректность входных данных
            ListStringResponseModel result = ValidateModel.ValidateMatrixSpotClientCodeModel(model);//MS MO RS FX
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"HttpGet Get/EDPFortsClientCode/ByMatrixCode Error: {result.Messages[0]}");
                return BadRequest(result);
            }

            result = _qService.GetEDPFortsClientCodeByMatrixCode(model);

            _logger.LogInformation($"HttpGet Get/EDPFortsClientCode/ByMatrixCode result isOK={result.IsSuccess}");
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

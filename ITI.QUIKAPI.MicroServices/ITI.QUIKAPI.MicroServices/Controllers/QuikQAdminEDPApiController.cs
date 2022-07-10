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
            _logger.LogInformation($"HttpGet Get/EDPFortsClientCode/ByMatrixCode {model.MatrixClientCode}");

            //проверим корректность входных данных
            ListStringResponseModel result = ValidateModel.ValidateMatrixSpotClientCodeModel(model);//MS MO RS FX
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"HttpGet Get/EDPFortsClientCode/ByMatrixCode Error: {result.Messages[0]}");
                return Ok(result);
            }

            result = _qService.GetEDPFortsClientCodeByMatrixCode(model);

            _logger.LogInformation($"HttpGet Get/EDPFortsClientCode/ByMatrixCode result isOK={result.IsSuccess}");
            
            return Ok(result);
        }
        [HttpGet("Get/EDPMatrixClientCode/ByFortsCode")]
        public IActionResult GetEDPMatrixClientCodeByFortsCode([FromQuery] FortsClientCodeModel model)
        {
            _logger.LogInformation($"HttpGet Get/EDPMatrixClientCode/ByFortsCode {model.FortsClientCode}");

            //проверим корректность входных данных
            ListStringResponseModel result = ValidateModel.ValidateMatrixFortsClientCodeModel(model.FortsClientCode);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"HttpGet Get/EDPMatrixClientCode/ByFortsCode Error: {result.Messages[0]}");
                return Ok(result);
            }

            result = _qService.GetEDPMatrixClientCodeByFortsCode(model);

            _logger.LogInformation($"HttpGet Get/EDPMatrixClientCode/ByFortsCode  result isOK={result.IsSuccess}");

            return Ok(result);
        }

        [HttpPost("SetNewEdpRelation")]
        public IActionResult SetNewEdpRelation([FromBody] MatrixToFortsCodesMappingModel model)
        {
            _logger.LogInformation($"HttpPost SetNewEdpRelation Call, {model.MatrixClientCode} -> {model.FortsClientCode}");
            
            //проверим корректность входных данных
            ListStringResponseModel result = ValidateModel.ValidateMatrixToFortsCodesMappingModel(model);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"HttpPost SetNewEdpRelation Error: {result.Messages[0]}");
                return Ok(result);
            }

            result = _qService.SetNewEdpRelation(model);

            return Ok(result);
        }

        [HttpDelete("DeleteEdpRelation")]
        public IActionResult DeleteEdpRelation([FromQuery] MatrixClientCodeModel model)
        {
            _logger.LogInformation($"HttpDelete DeleteEdpRelation Call for {model.MatrixClientCode}");
            
            //проверим корректность входных данных
            ListStringResponseModel result = ValidateModel.ValidateMatrixSpotClientCodeModel(model);//MS MO RS FX
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"HttpDelete DeleteEdpRelation Error: {result.Messages[0]}");
                return Ok(result);
            }

            result = _qService.DeleteEdpRelation(model);

            return Ok(result);
        }

        [HttpGet("Get/AllEdpRelation")]
        public IActionResult GetAllEdpRelation()
        {
            _logger.LogInformation("HttpGet Get/AllEdpRelation");

            ListStringResponseModel result = _qService.GetAllEdpRelation();

            _logger.LogInformation($"HttpGet Get/AllEdpRelation result isOK={result.IsSuccess}");

            return Ok(result);
        }
    }
}

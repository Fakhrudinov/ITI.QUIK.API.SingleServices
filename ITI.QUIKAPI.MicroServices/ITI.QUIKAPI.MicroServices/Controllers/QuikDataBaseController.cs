using DataAbstraction.Interfaces;
using DataAbstraction.Models;
using DataAbstraction.Models.DataBaseModels;
using DataAbstraction.Models.Responses;
using DataValidationService;
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
        public async Task<IActionResult> GetRegisteredCodesForts([FromQuery] IEnumerable<string> codes)
        {
            _logger.LogInformation("HttpGet Get/RegisteredCodes Call");
            ListStringResponseModel validateRresult = new ListStringResponseModel();

            //проверим корректность входных данных
            if (codes.Count() == 0)
            {
                validateRresult.IsSuccess = false;
                validateRresult.Messages.Add("QuikDataBase/Get/RegisteredCodes code must contain at least 1 code");
                return BadRequest(validateRresult);
            }
            validateRresult = ValidateModel.ValidateMixedClientCodesArray(codes);
            if (!validateRresult.IsSuccess)
            {
                _logger.LogInformation($"HttpGet GetAllClientsFromTemplate/PoKomissii Error: {validateRresult.Messages[0]}");
                return BadRequest(validateRresult);
            }

            DataBaseClientCodesResponse result = await _repository.GetRegisteredCodes(codes);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("Set/NewClient/ToMNP")]
        public async Task<IActionResult> SetNewClientToMNP([FromBody] NewMNPClientModel model)
        {
            _logger.LogInformation("HttpPost Set/NewClient/ToMNP Call");
            ListStringResponseModel response = new ListStringResponseModel();

            //проверим корректность входных данных
            response = ValidateModel.ValidateNewMNPClientModel(model);
            if (!response.IsSuccess)
            {
                _logger.LogInformation($"HttpPost Set/NewClient/ToMNP Error: {response.Messages[0]}");
                return BadRequest(response);
            }

            response = await _repository.SetNewClientToMNP(model);

            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}

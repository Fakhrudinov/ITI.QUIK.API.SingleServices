using DataAbstraction.Interfaces;
using DataAbstraction.Models;
using DataValidationService;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace ITI.QUIKAPI.MicroServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuikSftpServerController : ControllerBase
    {
        private ILogger<QuikQAdminSpotApiController> _logger;
        private ISFTPService _serviceSFTP;

        public QuikSftpServerController(ILogger<QuikQAdminSpotApiController> logger, ISFTPService serviceSFTP)
        {
            _logger = logger;
            _serviceSFTP = serviceSFTP;
        }

        [HttpGet("CheckConnections/ServerSFTP")]
        public IActionResult CheckConnection()
        {
            _logger.LogInformation("HttpGet CheckConnections/ServerSFTP Call");

            var result = _serviceSFTP.CheckConnections();

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }


        [HttpGet("GetStartMessage/forAll")]
        public IActionResult GetStartMessageforAll()
        {
            _logger.LogInformation("HttpGet GetStartMessage/forAll Call");

            var result = _serviceSFTP.GetStartMessageforAll();

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("GetStartMessage/forUID/{uid}")]
        public IActionResult GetStartMessageforUID(int uid)
        {
            _logger.LogInformation($"HttpGet GetStartMessage/forUID/{uid} Call");

            var result = _serviceSFTP.GetStartMessageforUID(uid);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }


        [HttpDelete("DeleteStartMessage/ForAll")]
        public IActionResult DeleteStartMessageForAll()
        {
            _logger.LogInformation($"HttpDelete DeleteStartMessage/ForAll");

            var result = _serviceSFTP.DeleteStartMessageForAll();

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete("DeleteStartMessage/ForUID/{uid}")]
        public IActionResult DeleteStartMessageForUID(int uid)
        {
            _logger.LogInformation($"HttpDelete DeleteStartMessage/ForUID/{uid}");

            var result = _serviceSFTP.DeleteStartMessageForUID(uid);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("SetStartMessage")]
        public IActionResult SetStartMessage([FromBody] StartMessageModel model)
        {
            _logger.LogInformation($"HttpPost SetStartMessage Call, ToAll={model.ToAll} UID={model.UID}");

            var result = _serviceSFTP.SetStartMessage(model);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("UID/byMatrixCode")]
        public IActionResult GetUIDByMatrixCode([FromQuery] MatrixClientCodeModel model)
        {
            _logger.LogInformation("HttpGet GetUID/ByMatrixCode Call " + model.MatrixClientCode);

            SingleMatrixCodeStringValidationService validator = new SingleMatrixCodeStringValidationService();
            ValidationResult validationResult = validator.Validate(model.MatrixClientCode);
            if (!validationResult.IsValid)
            {
                var response = new StringResponceModel();
                response.Message = validationResult.Errors.First().ErrorCode + " " + validationResult.Errors.First().ErrorMessage;
                response.IsSuccess = false;

                _logger.LogWarning("HttpGet GetUID/ByMatrixCode Failed with " + response.Message);
                return BadRequest(response);
            }

            var result = _serviceSFTP.GetUIDByMatrixCode(model.MatrixClientCode);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("UID/byFortsCode")]
        public IActionResult GetUIDByFortsCode([FromQuery] FortsClientCodeModel model)
        {
            _logger.LogInformation($"HttpGet GetUID/ByFortsCode Call " + model.FortsClientCode);

            SingleFortsCodeStringValidationService validator = new SingleFortsCodeStringValidationService();
            ValidationResult validationResult = validator.Validate(model.FortsClientCode);
            if (!validationResult.IsValid)
            {
                var response = new StringResponceModel();
                response.Message = validationResult.Errors.First().ErrorCode + " " + validationResult.Errors.First().ErrorMessage;
                response.IsSuccess = false;

                _logger.LogWarning("HttpGet GetUID/ByFortsCode Failed with " + response.Message);
                return BadRequest(response);
            }

            var result = _serviceSFTP.GetUIDByFortsCode(model.FortsClientCode);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }


        [HttpPost("NewClient/OptionWorkshop")]
        public IActionResult NewClientOptionWorkshop([FromBody] NewClientOptionWorkShopModel model)
        {
            _logger.LogInformation($"HttpPost NewClient/OptionWorkshop Call for {model.Client.FirstName} {model.Client.LastName}");

            var responseList = new ListStringResponseModel();
            NewClientOptionWorkshopValidationService validator = new NewClientOptionWorkshopValidationService();
            ValidationResult validationResult = validator.Validate(model);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);

                string errors = SetResponseFromValidationResult.GetErrorsCodeFromValidationResult(validationResult);
                _logger.LogWarning("HttpPost NewClient/OptionWorkshop Failed with " + errors);
                return BadRequest(responseList);
            }

            var result = _serviceSFTP.SendNewClientOptionWorkshop(model);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("NewClient")]
        public IActionResult NewClient([FromBody] NewClientModel model)
        {
            _logger.LogInformation($"HttpPost NewClient Call for {model.Client.FirstName} {model.Client.LastName}");

            var responseList = new ListStringResponseModel();
            NewClientValidationService validator = new NewClientValidationService();
            ValidationResult validationResult = validator.Validate(model);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);

                string errors = SetResponseFromValidationResult.GetErrorsCodeFromValidationResult(validationResult);
                _logger.LogWarning("HttpPost NewClient Failed with " + errors);
                return BadRequest(responseList);
            }

            var result = _serviceSFTP.SendNewClient(model);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("RequestFile/AllClients")]
        public IActionResult RequestAllClients()
        {
            _logger.LogInformation("HttpGet RequestFile/AllClients Call");

            var result = _serviceSFTP.RequestFileAllClients();

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("DownloadFile/AllClients")]
        public IActionResult DownloadAllClients()
        {
            _logger.LogInformation("HttpGet DownloadFile/AllClients Call");

            var result = _serviceSFTP.DownloadAllClients();

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("BackUpFileCodesIni")]
        public IActionResult GetFileCodesIni()
        {
            _logger.LogInformation("HttpGet BackUpFileCodesIni Call");

            var result = _serviceSFTP.BackUpFileCodesIni();

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("BackUpFileDealLibIni")]
        public IActionResult GetFileDealLibIni()
        {
            _logger.LogInformation("HttpGet BackUpFileDealLibIni Call");

            var result = _serviceSFTP.BackUpFileDealLibIni();

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("BackUpFileSpbfutlibIni")]
        public IActionResult GetFileSpbfutlibIni()
        {
            _logger.LogInformation("HttpGet BackUpFileSpbfutlibIni Call");

            var result = _serviceSFTP.BackUpFileSpbfutlibIni();

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut("AddClientCodesToFileCodesIni")]
        public IActionResult AddMatrixCodesToFileCodesIni([FromBody] CodesArrayModel model)
        {
            _logger.LogInformation("HttpPut AddMatrixCodesToFileCodesIni Call");

            var responseList = new ListStringResponseModel();
            MatrixArrayCodesValidationService validator = new MatrixArrayCodesValidationService();
            ValidationResult validationResult = validator.Validate(model);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);

                string errors = SetResponseFromValidationResult.GetErrorsCodeFromValidationResult(validationResult);
                _logger.LogWarning("HttpPut AddMatrixCodesToFileCodesIni Failed with " + errors);
                return BadRequest(responseList);
            }

            var result = _serviceSFTP.AddMAtrixCodesToFileCodesIni(model);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete("BlockUserBy/UID/{uid}")]
        public IActionResult BlockUserByUID(int uid)
        {
            _logger.LogInformation($"HttpDelete BlockUserBy/UID/{uid} Call");

            var result = _serviceSFTP.BlockUserByUID(uid);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete("BlockUserBy/MatrixClientCode")]
        public IActionResult BlockUserByMatrixClientCode([FromBody] MatrixClientCodeModel model)
        {
            _logger.LogInformation($"HttpDelete BlockUserBy/MatrixClientCode/{model.MatrixClientCode} Call");

            SingleMatrixCodeStringValidationService validator = new SingleMatrixCodeStringValidationService();
            ValidationResult validationResult = validator.Validate(model.MatrixClientCode);
            if (!validationResult.IsValid)
            {
                var response = new StringResponceModel();
                response.Message = validationResult.Errors.First().ErrorCode + " " + validationResult.Errors.First().ErrorMessage;
                response.IsSuccess = false;

                _logger.LogWarning("HttpDelete BlockUserBy/MatrixClientCode Failed with " + response.Message);
                return BadRequest(response);
            }

            var result = _serviceSFTP.BlockUserByMatrixClientCode(model.MatrixClientCode);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete("BlockUserBy/FortsClientCode")]
        public IActionResult BlockUserByFortsClientCode([FromBody] FortsClientCodeModel model)
        {
            _logger.LogInformation($"HttpDelete BlockUserBy/FortsClientCode/{model.FortsClientCode} Call");

            SingleFortsCodeStringValidationService validator = new SingleFortsCodeStringValidationService();
            ValidationResult validationResult = validator.Validate(model.FortsClientCode);
            if (!validationResult.IsValid)
            {
                var response = new StringResponceModel();
                response.Message = validationResult.Errors.First().ErrorCode + " " + validationResult.Errors.First().ErrorMessage;
                response.IsSuccess = false;

                _logger.LogWarning("HttpDelete BlockUserBy/FortsClientCode Failed with " + response.Message);
                return BadRequest(response);
            }

            var result = _serviceSFTP.BlockUserByFortsClientCode(model.FortsClientCode);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut("SetNewPubringKeyBy/MatrixClientCode")]
        public IActionResult SetNewPubringKeyByMatrixClientCode([FromBody] MatrixCodeAndPubringKeyModel model)
        {
            _logger.LogInformation("HttpPut SetNewPubringKey/ByMatrixClientCode Call " + model.ClientCode);

            SingleMatrixCodeStringValidationService validator = new SingleMatrixCodeStringValidationService();
            ValidationResult validationResult = validator.Validate(model.ClientCode.MatrixClientCode);
            if (!validationResult.IsValid)
            {
                var response = new StringResponceModel();
                response.Message = validationResult.Errors.First().ErrorCode + " " + validationResult.Errors.First().ErrorMessage;
                response.IsSuccess = false;

                _logger.LogWarning("HttpPut SetNewPubringKey/ByMatrixClientCode Failed with " + response.Message);
                return BadRequest(response);
            }

            var result = _serviceSFTP.SetNewPubringKeyByMatrixClientCode(model);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut("SetNewPubringKeyBy/FortsClientCode")]
        public IActionResult SetNewPubringKeyByFortsClientCode([FromBody] FortsCodeAndPubringKeyModel model)
        {
            _logger.LogInformation("HttpPut SetNewPubringKey/ByFortsClientCode Call " + model.ClientCode);

            SingleFortsCodeStringValidationService validator = new SingleFortsCodeStringValidationService();
            ValidationResult validationResult = validator.Validate(model.ClientCode.FortsClientCode);
            if (!validationResult.IsValid)
            {
                var response = new StringResponceModel();
                response.Message = validationResult.Errors.First().ErrorCode + " " + validationResult.Errors.First().ErrorMessage;
                response.IsSuccess = false;

                _logger.LogWarning("HttpPut SetNewPubringKey/ByFortsClientCode Failed with " + response.Message);
                return BadRequest(response);
            }

            var result = _serviceSFTP.SetNewPubringKeyByFortsClientCode(model);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("GetResultOfXMLFileUpload")]
        public IActionResult GetResultOfXMLFileUpload(string file)
        {
            _logger.LogInformation("HttpGet GetResultOfXMLFileUpload Call " + file);

            var result = _serviceSFTP.GetResultOfXMLFileUpload(file);

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

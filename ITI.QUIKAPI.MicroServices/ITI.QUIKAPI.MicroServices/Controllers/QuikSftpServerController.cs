using DataAbstraction.Interfaces;
using DataAbstraction.Models;
using DataValidationService;
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
            _logger.LogInformation($"HttpGet GetUID/ByMatrixCode {model.MatrixClientCode} Call ");

            //проверим корректность входных данных
            ListStringResponseModel result = ValidateModel.ValidateMatrixSpotClientCodeModel(model);//MS MO RS FX
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"HttpGet GetUID/ByMatrixCode {model.MatrixClientCode} Error: {result.Messages[0]}");
                return BadRequest(result);
            }

            result = _serviceSFTP.GetUIDByMatrixCode(model.MatrixClientCode);

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
            _logger.LogInformation($"HttpGet GetUID/ByFortsCode {model.FortsClientCode} Call ");

            //проверим корректность входных данных
            ListStringResponseModel result = ValidateModel.ValidateMatrixFortsClientCodeModel(model.FortsClientCode);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"HttpGet GetUID/ByFortsCode {model.FortsClientCode} Error: {result.Messages[0]}");
                return BadRequest(result);
            }

            result = _serviceSFTP.GetUIDByFortsCode(model.FortsClientCode);

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

            //проверим корректность входных данных
            ListStringResponseModel result = ValidateModel.ValidateNewClientOptionWorkShopModel(model);
            if (!result.IsSuccess)
            {
                _logger.LogWarning("HttpPost NewClient/OptionWorkshop Failed with " + result.Messages[0]);
                return BadRequest(result);
            }

            result = _serviceSFTP.SendNewClientOptionWorkshop(model);

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

            //проверим корректность входных данных
            ListStringResponseModel result = ValidateModel.ValidateNewClientModel(model);
            if (!result.IsSuccess)
            {
                _logger.LogWarning("HttpPost NewClient Failed with " + result.Messages[0]);
                return BadRequest(result);
            }

            result = _serviceSFTP.SendNewClient(model);

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

            //проверим корректность входных данных
            ListStringResponseModel result = ValidateModel.ValidateCodesArrayModel(model);
            if (!result.IsSuccess)
            {
                _logger.LogWarning("HttpPut AddMatrixCodesToFileCodesIni Failed with " + result.Messages[0]);
                return BadRequest(result);
            }

            result = _serviceSFTP.AddMAtrixCodesToFileCodesIni(model);

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

            //проверим корректность входных данных
            ListStringResponseModel result = ValidateModel.ValidateMatrixSpotClientCodeModel(model);//MS MO RS FX
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"HttpDelete BlockUserBy/MatrixClientCode/{model.MatrixClientCode} Error: {result.Messages[0]}");
                return BadRequest(result);
            }

            result = _serviceSFTP.BlockUserByMatrixClientCode(model.MatrixClientCode);

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

            //проверим корректность входных данных
            ListStringResponseModel result = ValidateModel.ValidateMatrixFortsClientCodeModel(model.FortsClientCode);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"HttpDelete BlockUserBy/FortsClientCode/{model.FortsClientCode} Error: {result.Messages[0]}");
                return BadRequest(result);
            }

            result = _serviceSFTP.BlockUserByFortsClientCode(model.FortsClientCode);

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

            //проверим корректность входных данных
            ListStringResponseModel result = ValidateModel.ValidateMatrixCodeAndPubringKeyModel(model);
            if (!result.IsSuccess)
            {
                _logger.LogWarning("HttpPut SetNewPubringKey/ByMatrixClientCode Failed with " + result.Messages[0]);
                return BadRequest(result);
            }

            result = _serviceSFTP.SetNewPubringKeyByMatrixClientCode(model);

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

            //проверим корректность входных данных
            ListStringResponseModel result = ValidateModel.ValidateFortsCodeAndPubringKeyModel(model);
            if (!result.IsSuccess)
            {
                _logger.LogWarning("HttpPut SetNewPubringKey/ByFortsClientCode Failed with " + result.Messages[0]);
                return BadRequest(result);
            }

            result = _serviceSFTP.SetNewPubringKeyByFortsClientCode(model);

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

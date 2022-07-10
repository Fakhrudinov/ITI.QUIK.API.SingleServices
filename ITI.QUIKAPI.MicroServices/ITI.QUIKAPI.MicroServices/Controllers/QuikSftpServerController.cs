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

            return Ok(result);
        }


        [HttpGet("GetStartMessage/forAll")]
        public IActionResult GetStartMessageforAll()
        {
            _logger.LogInformation("HttpGet GetStartMessage/forAll Call");

            var result = _serviceSFTP.GetStartMessageforAll();

            return Ok(result);
        }
        [HttpGet("GetStartMessage/forUID/{uid}")]
        public IActionResult GetStartMessageforUID(int uid)
        {
            _logger.LogInformation($"HttpGet GetStartMessage/forUID/{uid} Call");

            var result = _serviceSFTP.GetStartMessageforUID(uid);

            return Ok(result);
        }


        [HttpDelete("DeleteStartMessage/ForAll")]
        public IActionResult DeleteStartMessageForAll()
        {
            _logger.LogInformation($"HttpDelete DeleteStartMessage/ForAll");

            var result = _serviceSFTP.DeleteStartMessageForAll();

            return Ok(result);
        }

        [HttpDelete("DeleteStartMessage/ForUID/{uid}")]
        public IActionResult DeleteStartMessageForUID(int uid)
        {
            _logger.LogInformation($"HttpDelete DeleteStartMessage/ForUID/{uid}");

            var result = _serviceSFTP.DeleteStartMessageForUID(uid);

            return Ok(result);
        }

        [HttpPost("SetStartMessage")]
        public IActionResult SetStartMessage([FromBody] StartMessageModel model)
        {
            _logger.LogInformation($"HttpPost SetStartMessage Call, ToAll={model.ToAll} UID={model.UID}");

            var result = _serviceSFTP.SetStartMessage(model);

            return Ok(result);
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
                return Ok(result);
            }

            result = _serviceSFTP.GetUIDByMatrixCode(model.MatrixClientCode);

            return Ok(result);
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
                return Ok(result);
            }

            result = _serviceSFTP.GetUIDByFortsCode(model.FortsClientCode);

            return Ok(result);
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
                return Ok(result);
            }

            result = _serviceSFTP.SendNewClientOptionWorkshop(model);

            return Ok(result);
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
                return Ok(result);
            }

            result = _serviceSFTP.SendNewClient(model);

            return Ok(result);
        }

        [HttpGet("RequestFile/CurrClnts")]
        public IActionResult RequestCurrClnts()
        {
            _logger.LogInformation("HttpGet RequestFile/CurrClnts Call");

            var result = _serviceSFTP.RequestFileCurrClnts();

            return Ok(result);
        }

        [HttpGet("DownloadFile/CurrClnts")]
        public IActionResult DownloadCurrClnts()
        {
            _logger.LogInformation("HttpGet DownloadFile/CurrClnts Call");

            var result = _serviceSFTP.DownloadCurrClnts();

            return Ok(result);
        }

        [HttpGet("BackUpFileCodesIni")]
        public IActionResult GetFileCodesIni()
        {
            _logger.LogInformation("HttpGet BackUpFileCodesIni Call");

            var result = _serviceSFTP.BackUpFileCodesIni();

            return Ok(result);
        }

        [HttpGet("BackUpFileDealLibIni")]
        public IActionResult GetFileDealLibIni()
        {
            _logger.LogInformation("HttpGet BackUpFileDealLibIni Call");

            var result = _serviceSFTP.BackUpFileDealLibIni();

            return Ok(result);
        }

        [HttpGet("BackUpFileSpbfutlibIni")]
        public IActionResult GetFileSpbfutlibIni()
        {
            _logger.LogInformation("HttpGet BackUpFileSpbfutlibIni Call");

            var result = _serviceSFTP.BackUpFileSpbfutlibIni();

            return Ok(result);
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
                return Ok(result);
            }

            result = _serviceSFTP.AddMAtrixCodesToFileCodesIni(model);

            return Ok(result);
        }

        [HttpDelete("BlockUserBy/UID/{uid}")]
        public IActionResult BlockUserByUID(int uid)
        {
            _logger.LogInformation($"HttpDelete BlockUserBy/UID/{uid} Call");

            var result = _serviceSFTP.BlockUserByUID(uid);

            return Ok(result);
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
                return Ok(result);
            }

            result = _serviceSFTP.BlockUserByMatrixClientCode(model.MatrixClientCode);

            return Ok(result);
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
                return Ok(result);
            }

            result = _serviceSFTP.BlockUserByFortsClientCode(model.FortsClientCode);

            return Ok(result);
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
                return Ok(result);
            }

            result = _serviceSFTP.SetNewPubringKeyByMatrixClientCode(model);

            return Ok(result);
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
                return Ok(result);
            }

            result = _serviceSFTP.SetNewPubringKeyByFortsClientCode(model);

            return Ok(result);
        }

        [HttpPut("SetAllTrades/ByMatrixClientCode")]
        public IActionResult SetAllTradesByMatrixClientCode([FromBody] MatrixClientCodeModel model)
        {
            _logger.LogInformation("HttpPut SetAllTrades/ByMatrixClientCode Call " + model.MatrixClientCode);

            //проверим корректность входных данных
            ListStringResponseModel result = ValidateModel.ValidateMatrixSpotClientCodeModel(model);
            if (!result.IsSuccess)
            {
                _logger.LogWarning("HttpPut SetAllTrades/ByMatrixClientCode Failed with " + result.Messages[0]);
                return Ok(result);
            }

            result = _serviceSFTP.SetAllTradesByMatrixClientCode(model);

            return Ok(result);
        }

        [HttpPut("SetAllTradesBy/FortsClientCode")]
        public IActionResult SetAllTradesByFortsClientCode([FromBody] FortsClientCodeModel model)
        {
            _logger.LogInformation("HttpPut SetAllTradesBy/FortsClientCode Call " + model.FortsClientCode);

            //проверим корректность входных данных
            ListStringResponseModel result = ValidateModel.ValidateMatrixFortsClientCodeModel(model.FortsClientCode);
            if (!result.IsSuccess)
            {
                _logger.LogWarning("HttpPut SetAllTradesBy/FortsClientCode Failed with " + result.Messages[0]);
                return Ok(result);
            }

            result = _serviceSFTP.SetAllTradesByFortsClientCode(model);

            return Ok(result);
        }

        [HttpGet("GetResultOfXMLFileUpload")]
        public IActionResult GetResultOfXMLFileUpload(string file)
        {
            _logger.LogInformation("HttpGet GetResultOfXMLFileUpload Call " + file);

            var result = _serviceSFTP.GetResultOfXMLFileUpload(file);

            return Ok(result);
        }
    }
}

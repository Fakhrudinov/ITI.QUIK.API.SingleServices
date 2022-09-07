using DataAbstraction.Interfaces;
using DataAbstraction.Models;
using DataValidationService;
using Microsoft.AspNetCore.Mvc;

namespace ITI.QUIKAPI.MicroServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KvalAndTestsController : ControllerBase
    {
        private ISpotBrlService _qService;
        private ILogger<KvalAndTestsController> _logger;

        public KvalAndTestsController(ISpotBrlService qService, ILogger<KvalAndTestsController> logger)
        {
            _qService = qService;
            _logger = logger;
        }

        [HttpPost("Replace/KvalInvestorsList")]
        public IActionResult ReplaceKvalInvestorsList([FromBody] CodesArrayModel model)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Httppost Replace/KvalInvestorsList Call with {model.MatrixClientPortfolios.Length} portfolios");

            //проверим корректность входных данных
            ListStringResponseModel result = ValidateModel.ValidateCodesArrayModel(model);
            if (!result.IsSuccess)
            {
                _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpPost Replace/KvalInvestorsList Failed with " + result.Messages[0]);
                return Ok(result);
            }

            result = _qService.ReplaceKvalInvestorsList(model);

            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Httppost Replace/KvalInvestorsList result isOK={result.IsSuccess}");

            return Ok(result);
        }

        [HttpPost("Replace/NonKvalInvestorsWithTestsArray")]
        public IActionResult ReplaceNonKvalInvestorsWithTestsArray([FromBody] QCodeAndListOfComplexProductsTestsModel[] modelArray)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Httppost Replace/NonKvalInvestorsWithTestsArray Call with {modelArray.Length} portfolios/tests");

            //проверим корректность входных данных
            ListStringResponseModel result = ValidateModel.ValidateQCodeAndListOfComplexProductsTestsModel(modelArray);
            if (!result.IsSuccess)
            {
                _logger.LogWarning($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpPost Replace/NonKvalInvestorsWithTestsArray Failed with " + result.Messages[0]);
                return Ok(result);
            }

            result = _qService.ReplaceNonKvalInvestorsWithTestsArray(modelArray);

            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} Httppost Replace/NonKvalInvestorsWithTestsArray result isOK={result.IsSuccess}");

            return Ok(result);
        }
    }
}

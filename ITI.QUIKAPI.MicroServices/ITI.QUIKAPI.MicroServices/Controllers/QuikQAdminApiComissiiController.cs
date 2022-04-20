using DataAbstraction.Interfaces;
using DataAbstraction.Models;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using DataValidationService;
using CommonServices;

namespace ITI.QUIKAPI.MicroServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuikQAdminApiComissiiController : ControllerBase
    {
        private ISpotBrlService _qService;
        private ILogger<QuikQAdminApiComissiiController> _logger;

        public QuikQAdminApiComissiiController(ISpotBrlService qService, ILogger<QuikQAdminApiComissiiController> logger)
        {
            _qService = qService;
            _logger = logger;
        }

        [HttpGet("OK")]
        public async Task<IActionResult> Ok()
        {
            _logger.LogInformation("QuikBRLEqComissiiController HttpGet OK Call");
            return Ok("Yes");
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            _logger.LogInformation("QuikBRLEqComissiiController HttpGet login Call");
            string result = _qService.GetLogin();
            _logger.LogInformation("QuikBRLEqComissiiController HttpGet login result = " + result);
            
            var response = new StringResponceModel();
            response.Message = result;
            return Ok(response);
        }

        [HttpGet("CheckConnections")]
        public IActionResult CheckConnection()
        {
            _logger.LogInformation("QuikBRLEqComissiiController HttpGet CheckConnections Call");

            var response = new StringResponceModel();
            var result = _qService.CheckConnection();            

            if (result == null)
            {
                _logger.LogWarning("QuikBRLEqComissiiController HttpGet CheckConnections Result = No answer received from QUIK BRL MC0138200000");
                response.IsSuccess = false;
                response.Message = "No answer received from QUIK BRL MC0138200000";
                return BadRequest(response);
            }
            else if (result.Equals("OK"))
            {
                _logger.LogInformation("QuikBRLEqComissiiController HttpGet CheckConnections Result = OK");

                response.Message = "OK";
                return Ok(response);
            }
            else
            {
                _logger.LogWarning("QuikBRLEqComissiiController HttpGet CheckConnections Result = " + result);
                response.IsSuccess = false;
                response.Message = "QuikBRLEqComissiiController HttpGet CheckConnections Result = " + result;
                return BadRequest(response);
            } 
        }

        [HttpPost("AddClientPortfolioTo/CD_portfolio/{portfolio}")]
        public IActionResult AddClientPortfolioToCD_portfolio(string portfolio)
        {
            _logger.LogInformation("QuikBRLEqComissiiController Httppost AddClientPortfolioTo/CD_portfolio Call, " + portfolio);

            CDPortfolioValidationService validator = new CDPortfolioValidationService();
            var responseList = new ListStringResponseModel();

            ValidationResult validationResult = validator.Validate(portfolio);

            if (!validationResult.IsValid)
            {
                responseList = SetResponseFromValidationResult.SetResponse(validationResult, responseList);

                string errors = SetResponseFromValidationResult.GetErrorsCodeFromValidationResult(validationResult);
                _logger.LogWarning("QuikBRLEqComissiiController Httppost AddClientPortfolioTo/CD_portfolio Failed with " + errors);
                return BadRequest(responseList);
            }

            string quikportfolio = PortfoliosConvertingService.GetCdPortfolio(portfolio);

            string result = _qService.AddClientPortfolioToCD_portfolio(quikportfolio);

            var response = new StringResponceModel();
            response.Message = result;

            if (result.Equals("OK"))
            {
                _logger.LogInformation("QuikBRLEqComissiiController Httppost AddClientPortfolioTo/CD_portfolio Result = OK");

                return Ok(response);
            }
            else
            {
                _logger.LogWarning("QuikBRLEqComissiiController Httppost AddClientPortfolioTo/CD_portfolio Failed with " + result);
                response.IsSuccess = false;                
                return BadRequest(response);
            }
        }


    }
}

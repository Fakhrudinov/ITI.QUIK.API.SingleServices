using DataAbstraction.Interfaces;
using DataAbstraction.Models;
using DataAbstraction.Models.Responses;
using DataValidationService;
using Microsoft.AspNetCore.Mvc;

namespace ITI.QUIKAPI.MicroServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private IDiscountsService _qService;
        private ILogger<DiscountsController> _logger;

        public DiscountsController(IDiscountsService qService, ILogger<DiscountsController> logger)
        {
            _qService = qService;
            _logger = logger;
        }

        [HttpGet("Get/SingleDiscount/FromGlobal/{security}")]
        public IActionResult GetSingleDiscountFromGlobal(string security)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpGet Get/SingleDiscount/FromGlobal/{security} Call ");
            DiscountSingleResponse result = new DiscountSingleResponse();

            //проверим корректность входных данных
            ListStringResponseModel validateResult = ValidateModel.ValidateSecurity(security);
            if (!validateResult.IsSuccess)
            {
                _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpGet Get/SingleDiscount/FromGlobal/{security} " +
                    $"validate Error: {validateResult.Messages[0]}");

                result.Discount = null;
                result.IsSuccess = false;
                result.Messages.AddRange(validateResult.Messages);
                return Ok(result);
            }

            result = _qService.GetSingleDiscountFromGlobal(security);

            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpGet Get/SingleDiscount/FromGlobal/{security} " +
                $"result isOK={result.IsSuccess}");

            return Ok(result);
        }

        [HttpPost("Post/SingleDiscount/ToGlobal")]
        public IActionResult PostSingleDiscountToGlobal([FromBody] DiscountAndSecurityModel model)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpPost Post/SingleDiscount/ToGlobal " +
                $"{model.Security} Call ");

            //проверим корректность входных данных
            ListStringResponseModel result = ValidateModel.ValidateSecurity(model.Security);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpPost Post/SingleDiscount/ToGlobal " +
                    $"validate Error: {result.Messages[0]}");
                return Ok(result);
            }

            result = _qService.PostSingleDiscountToGlobal(model);

            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpPost Post/SingleDiscount/ToGlobal " +
                $"{model.Security} result isOK={result.IsSuccess}");

            return Ok(result);
        }

        [HttpGet("Get/SingleDiscount/FromMarginTemplate/{template}/{security}")]
        public IActionResult GetSingleDiscountFromMarginTemplate(string template, string security)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpGet Get/SingleDiscount/FromMarginTemplate/{template}/{security} Call ");
            DiscountSingleResponse result = new DiscountSingleResponse();

            //проверим корректность входных данных
            ListStringResponseModel validateResult = ValidateModel.ValidateSecurity(security);
            if (!validateResult.IsSuccess)
            {
                _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpGet Get/SingleDiscount/FromMarginTemplate/{template}/{security} " +
                    $"validate Error: {validateResult.Messages[0]}");

                result.Discount = null;
                result.IsSuccess = false;
                result.Messages.AddRange(validateResult.Messages);
                return Ok(result);
            }

            validateResult = ValidateModel.ValidateTemplateName(template);
            if (!validateResult.IsSuccess)
            {
                _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpGet Get/SingleDiscount/FromMarginTemplate/{template}/{security} " +
                    $"Error: {validateResult.Messages[0]}");
                result.Discount = null;
                result.IsSuccess = false;
                result.Messages.AddRange(validateResult.Messages);

                return Ok(result);
            }

            result = _qService.GetSingleDiscountFromMarginTemplate(template, security);

            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpGet Get/SingleDiscount/FromMarginTemplate/{template}/{security} " +
                $"result isOK={result.IsSuccess}");

            return Ok(result);
        }

        [HttpPost("Post/SingleDiscount/ToMarginTemplate/{template}")]
        public IActionResult PostSingleDiscountToMarginTemplate([FromRoute] string template, [FromBody] DiscountAndSecurityModel model)
        {
            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpPost Post/SingleDiscount/ToMarginTemplate " +
                $"{template} {model.Security} Call ");

            //проверим корректность входных данных
            ListStringResponseModel result = ValidateModel.ValidateSecurity(model.Security);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpPost Post/SingleDiscount/ToMarginTemplate/ " +
                    $"{template} {model.Security} validate Error: {result.Messages[0]}");
                return Ok(result);
            }

            // проверить template
            result = ValidateModel.ValidateTemplateName(template);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpPost Post/SingleDiscount/ToMarginTemplate/{template} " +
                    $"Error: {result.Messages[0]}");
                return Ok(result);
            }
            ////проверим на наличие этого шаблона
            //ListStringResponseModel isTemplateExist = _qService.GetList(true, true, "");
            //if (!isTemplateExist.Messages.Contains(model.Template))
            //{
            //    result.IsSuccess = false;
            //    result.Messages.Add($"Httppost AddMatrixClientPortfolioTo/KomissiiTemplate Failed: Template {model.Template} not found");

            //    return Ok(result);
            //}



            result = _qService.PostSingleDiscountToMarginTemplate(template, model);

            _logger.LogInformation($"{DateTime.Now.ToString("HH:mm:ss:fffff")} HttpPost Post/SingleDiscount/ToMarginTemplate " +
                $"{model.Security} result isOK={result.IsSuccess}");

            return Ok(result);
        }
    }
}

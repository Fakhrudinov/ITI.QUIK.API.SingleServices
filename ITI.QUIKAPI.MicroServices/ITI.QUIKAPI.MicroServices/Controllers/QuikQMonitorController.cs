﻿using DataAbstraction.Interfaces;
using DataAbstraction.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITI.QUIKAPI.MicroServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuikQMonitorController : ControllerBase
    {
        private ILogger<QuikQMonitorController> _logger;
        private IQMonitorService _service;

        public QuikQMonitorController(ILogger<QuikQMonitorController> logger, IQMonitorService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("CheckConnections/QMonitorAPI")]
        public IActionResult CheckConnection()
        {
            _logger.LogInformation("HttpGet CheckConnections/QMonitorAPI Call");

            ListStringResponseModel result = _service.CheckConnections();

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("ReloadDealerLib/{library}")]
        public IActionResult ReloadDealerLib(string library)
        {
            _logger.LogInformation($"HttpGet ReloadDealerLib/{library} Call");

            //проверим корректность входных данных
            ListStringResponseModel result = DataValidationService.ValidateModel.ValidateDealerLibrary(library);
            if (!result.IsSuccess)
            {
                _logger.LogInformation($"HttpGet ReloadDealerLib/{library} Error: {result.Messages[0]}");
                return BadRequest(result);
            }            

            result = _service.ReloadDealerLib(library);

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

using DataAbstraction.Interfaces;
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
    }
}

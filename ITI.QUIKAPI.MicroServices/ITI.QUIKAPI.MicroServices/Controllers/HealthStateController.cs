using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITI.QUIKAPI.MicroServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthStateController : ControllerBase
    {
        [HttpGet("OK")]
        public IActionResult IsOk()
        {
            return Ok("Yes");
        }
    }
}

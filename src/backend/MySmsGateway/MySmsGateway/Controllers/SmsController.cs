using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MySmsGateway.Controllers
{
    public class SmsController : AppBaseController
    {
        [HttpGet]
        [Route("{refId}/status")]
        public IActionResult GetStatus([FromRoute] string refId)
        {
            return Ok();
        }
    }
}

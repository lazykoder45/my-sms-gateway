using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MySmsGateway.Controllers
{
    public class DeviceController : AppBaseController
    {
        [HttpGet]
        [Route("user-devices/{userId}")]
        public IActionResult GetDevices([FromRoute] string userId)
        {
            return Ok();
        }
    }
}

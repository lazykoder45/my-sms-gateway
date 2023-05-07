using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySmsGateway.Entity.VM;

namespace MySmsGateway.Controllers
{
    public class UserController : AppBaseController
    {
        [HttpGet]
        [Route("{userId}/profile")]
        public IActionResult Profile([FromRoute] string userId)
        {
            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginVm model)
        {
            return Ok(model);
        }
    }
}

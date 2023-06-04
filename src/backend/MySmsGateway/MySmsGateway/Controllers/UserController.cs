using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySmsGateway.Entity.VM;
using MySmsGateway.Services;

namespace MySmsGateway.Controllers
{
    public class UserController : AppBaseController
    {
        private readonly UserService service;
        private readonly NotificationService notificationService;
        public UserController(UserService service,NotificationService notificationService)
        {
            this.service = service;
            this.notificationService = notificationService;
        }

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

        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] RegisterVm model)
        {
            service.Register(model);
            return Ok(model);
        }
    }
}

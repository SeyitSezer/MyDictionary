using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyDictionary.Model.User.Request;

namespace MyDictionary.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController(ILogger<UserController> logger, IMediator mediator) : ControllerBase
    {
        private readonly ILogger<UserController> logger = logger;
        private readonly IMediator mediator = mediator;

        [HttpPost("SaveUser")]
        public IActionResult SaveUser(UserRequest request)
        {
            return Ok(mediator.Send(request));
        }
    }
}

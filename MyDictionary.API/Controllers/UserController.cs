using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyDictionary.Model.Users.Request;

namespace MyDictionary.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController(ILogger<UserController> logger, IMediator mediator) : ControllerBase
    {
        private readonly ILogger<UserController> logger = logger;
        private readonly IMediator mediator = mediator;

        [HttpPost("SaveUser")]
        public async Task<IActionResult> SaveUser(User request)
        {
            return Ok(await mediator.Send(request));
        }

        [HttpPost("GetUser")]
        public async Task<IActionResult> GetUser(GetUser request)
        {
            return Ok(await mediator.Send(request));
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers(string Password)
        {
            GetAllUser req = new();
            if (Password == "12321")
                return Ok(await mediator.Send(req));
            else
                return Unauthorized("Incorrect Password");
        }
    }
}

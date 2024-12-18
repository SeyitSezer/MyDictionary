using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyDictionary.Model.Customer.Request;

namespace MyDictionary.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CustomerController(ILogger<CustomerController> logger, IMediator mediator) : ControllerBase
    {
        private readonly ILogger<CustomerController> logger = logger;
        private readonly IMediator mediator = mediator;

        [HttpPost("SaveCustomer")]
        public IActionResult SaveCUstomer(CustomerRequest request)
        {
            return Ok(mediator.Send(request));
        }
    }
}

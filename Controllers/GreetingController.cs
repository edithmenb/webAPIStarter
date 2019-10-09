using Microsoft.AspNetCore.Mvc;

namespace webAPIStarter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GreetingController: ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello from .NET Core!!";
            
        }
    }
}
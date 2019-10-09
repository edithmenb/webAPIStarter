using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
namespace webAPIStarter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GreetingController: ControllerBase
    {
        //New
         public string appName { get; set; }

        public GreetingController(IConfiguration config){
            appName = config.GetValue<string>("applicationName");
        }
        [HttpGet]
        public string Get()
        {
            return appName;
        }
    }
}
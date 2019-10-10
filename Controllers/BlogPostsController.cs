using Microsoft.AspNetCore.Mvc;

namespace webAPIStarter.Controllers
{
    [ApiController]
    [Route("api/BlogPosts")]
    public class BlogPostsController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Get method!";
        }
        [HttpPost]
        public string Post()
        {
            return "Post method!";
        }
        [HttpPut]
        public string Put()
        {
            return "Put method!";
        }
        [HttpDelete]
        public string Delete() 
        {
            return "Delete method!";
        }
    }
}
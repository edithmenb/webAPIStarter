using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using webAPIStarter.Models;

namespace webAPIStarter.Controllers
{
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        public List<PostModel> posts;
        public BlogPostsController() 
        {
            posts = new List<PostModel>
            {
                new PostModel { Id = 1, Title = "First Post", Author = "Oscar Recio", Content = "First Post by Oscar Recio"},
                new PostModel { Id = 2, Title = "Second Post", Author = "Edith Mendoza", Content = "Second Post by Edith Mendoza"},
                new PostModel { Id = 3, Title = "Third Post", Author = "Diego", Content = "Third Post by Diego"}
            };
        }
        [HttpGet("api/BlogPosts")]
        public string Get()
        {
            return "Get method!";
        }
        [HttpPost("api/BlogPosts")]
        public string Insert()
        {
            PostModel newPost = new PostModel 
            {
                Id = 4, 
                Title = "Fourth Post", 
                Author = "Alejandro", 
                Content = "Fourth Post by Alejandro" 
            };
            this.posts.Add(newPost);

            return "Fourth Post Added!";
        }
        [HttpPut("api/BlogPosts")]
        public string Put()
        {
            return "Put method!";
        }
        [HttpDelete("api/BlogPosts")]
        public string Delete() 
        {
            return "Delete method!";
        }
    }
}
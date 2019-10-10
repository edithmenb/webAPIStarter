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
        public List<PostModel> Get()
        {
            return this.posts;
        }

        [HttpGet("api/BlogPosts/{Id}")]
        public PostModel GetById([FromRoute] long Id)
        {
            foreach(PostModel post in this.posts)
            {
                if(post.Id == Id)
                {
                    return post;
                }
            }
            return null;
        }

        [HttpPost("api/BlogPosts")]
        public PostModel Insert([FromBody]PostModel newPost)
        {
            newPost.Id = this.posts.Count + 1;
            this.posts.Add(newPost);

            return this.posts[this.posts.Count - 1];
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
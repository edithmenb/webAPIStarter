using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using webAPIStarter.Models;

namespace webAPIStarter.Controllers
{
    [ApiController]
    [Route("api/BlogPosts")]
    public class BlogPostController: ControllerBase
    {
        public List<PostModel> posts;
        public BlogPostController()
        {
            posts = new List<PostModel>{
                new PostModel { Id = 1, Title = "First PostModel", Author = "Oscar Recio", Content = "First PostModel by Oscar Recio"},
                new PostModel { Id = 2, Title = "Second PostModel", Author = "Edith Mendoza", Content = "Second PostModel by Edith Mendoza"},
                new PostModel { Id = 3, Title = "Third PostModel", Author = "Diego", Content = "Third PostModel by Diego"}
            };
        }
        [HttpGet]
        public List<PostModel> GetAllPosts()
        {
            return this.posts;
        }

        [HttpGet("{Id}")]
        [Produces("application/xml")]
        public PostModel GetById([FromRoute] long Id)
        {
            foreach (PostModel post in this.posts)
            {
                if(post.Id == Id){
                    return post;
                }
            }
            return null;
        }

        [HttpPost]
        [Consumes("application/xml")]
        public PostModel InsertNewPost([FromBody]PostModel newPost)
        {
            newPost.Id = this.posts.Count+1;
            posts.Add(newPost);
            return this.posts[this.posts.Count-1];
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
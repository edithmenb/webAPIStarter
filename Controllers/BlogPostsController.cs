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
        // [Produces("application/xml")]
        public IActionResult GetById([FromRoute] long Id)
        {
            foreach (PostModel post in this.posts)
            {
                if(post.Id == Id){
                    return Ok(post);
                }
            }
            return NoContent();
        }

        [HttpPost]
        // [Consumes("application/xml")]
        public IActionResult InsertNewPost([FromBody]PostModel newPost)
        {
            if (ModelState.IsValid)
            {
                newPost.Id = this.posts.Count+1;
                posts.Add(newPost);
                foreach(PostModel post in posts){
                    if (post.Id == newPost.Id) {
                        return StatusCode(201);
                    }
                }
                return StatusCode(500, new { errorMessage = "Could not store value"});
            }
            else
            {
                return base.ValidationProblem();
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] PostModel updatedPost)
        {
            if (ModelState.IsValid)
            {
                foreach(PostModel post in posts)
                {
                    if (post.Id == updatedPost.Id)
                    {
                        post.Title = updatedPost.Title;
                        post.Author = updatedPost.Author;
                        post.Content = updatedPost.Content;
                        return Ok();
                    }
                }
                return NoContent();
            }
            else
            {
                return base.ValidationProblem();
            }
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] long id) 
        {
            foreach(PostModel post in posts)
            {
                if (post.Id == id)
                {
                    posts.Remove(post);
                    return StatusCode(410);
                }
            }
            return NotFound();
        }

    }
}
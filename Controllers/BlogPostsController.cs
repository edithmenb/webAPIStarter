using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using webAPIStarter.BlogPostService;
using webAPIStarter.Models;

namespace webAPIStarter.Controllers
{
    [ApiController]
    [Route("api/BlogPosts")]
    public class BlogPostController: ControllerBase
    {
        public IBlogPostService postService;
        public BlogPostController(IBlogPostService postService)
        {
            this.postService = postService;
        }

        [HttpGet]
        public IList<PostModel> GetAllPosts()
        {
            return this.postService.GetAll();
        }

        [HttpGet("{Id}")]
        // [Produces("application/xml")]
        public IActionResult GetById([FromRoute] long Id)
        {
            var result = this.postService.GetById(Id);
            if (result != null) return Ok(result);
            return NoContent();
        }

        [HttpPost]
        // [Consumes("application/xml")]
        public IActionResult InsertNewPost([FromBody]PostModel newPost)
        {
            if(ModelState.IsValid)
            {
                newPost = this.postService.Insert(newPost);
                return CreatedAtAction("GetById", new { newPost.Id }, newPost);
            }
            return base.ValidationProblem();
            
            // if (ModelState.IsValid)
            // {
            //     newPost.Id = this.posts.Count+1;
            //     posts.Add(newPost);
            //     foreach(PostModel post in posts){
            //         if (post.Id == newPost.Id) {
            //             return StatusCode(201);
            //         }
            //     }
            //     return StatusCode(500, new { errorMessage = "Could not store value"});
            // }
            // else
            // {
            //     return base.ValidationProblem();
            // }
        }

        [HttpPut]
        public IActionResult Put([FromBody] PostModel updatedPost)
        {
            postService.Update(updatedPost);
            if(postService.GetById(updatedPost.Id) != null)
            {
                return NoContent();
            }
            return NotFound();
            // if (ModelState.IsValid)
            // {
            //     foreach(PostModel post in posts)
            //     {
            //         if (post.Id == updatedPost.Id)
            //         {
            //             post.Title = updatedPost.Title;
            //             post.Author = updatedPost.Author;
            //             post.Content = updatedPost.Content;
            //             return Ok();
            //         }
            //     }
            //     return NoContent();
            // }
            // else
            // {
            //     return base.ValidationProblem();
            // }
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete([FromRoute] long id) 
        {
            PostModel deletedPost = postService.GetById(id);

            if(deletedPost == null)
            {
                return NotFound();
            }
            postService.Delete(deletedPost);
            return StatusCode(410);
            // foreach(PostModel post in posts)
            // {
            //     if (post.Id == id)
            //     {
            //         posts.Remove(post);
            //         return StatusCode(410);
            //     }
            // }
            // return NotFound();
        }

    }
}
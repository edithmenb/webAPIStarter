using System.Collections.Generic;
using WebAPIStarterData.Models;

namespace webAPIStarter.BlogPostService
{
    public class InMemoryPostService : IBlogPostService
    {
        private IList<BlogPost> posts;

        public InMemoryPostService(List<BlogPost> posts = null)
        {
            this.posts = posts ?? new List<BlogPost>();
        }
        public void Delete(BlogPost deletedPost)
        {
            foreach(BlogPost post in posts)
            {
                if(post.Id == deletedPost.Id)
                {
                    posts.Remove(post);
                }
            }
        }

        public IList<BlogPost> GetAll()
        {
            return this.posts;
        }

        public BlogPost GetById(long Id)
        {
            foreach(BlogPost post in posts)
            {
                if(post.Id == Id)
                {
                    return post;
                }
            }
            return null;
        }

        public BlogPost Insert(BlogPost newPost)
        {
            newPost.Id = this.posts.Count + 1;
            this.posts.Add(newPost);
            return newPost;
        }

        public void Update(BlogPost updatedPost)
        {
            foreach(BlogPost post in posts)
            {
                if(post.Id == updatedPost.Id)
                {
                    post.Title = updatedPost.Title;
                    post.Author = updatedPost.Author;
                    post.Content = updatedPost.Content;
                }
            }
        }
    }
}
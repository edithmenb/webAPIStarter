using System.Collections.Generic;
using webAPIStarter.Models;

namespace webAPIStarter.BlogPostService
{
    public class InMemoryPostService : IBlogPostService
    {
        private IList<PostModel> posts;

        public InMemoryPostService(List<PostModel> posts = null)
        {
            this.posts = posts ?? new List<PostModel>();
        }
        public void Delete(PostModel deletedPost)
        {
            foreach(PostModel post in posts)
            {
                if(post.Id == deletedPost.Id)
                {
                    posts.Remove(post);
                }
            }
        }

        public IList<PostModel> GetAll()
        {
            return this.posts;
        }

        public PostModel GetById(long Id)
        {
            foreach(PostModel post in posts)
            {
                if(post.Id == Id)
                {
                    return post;
                }
            }
            return null;
        }

        public PostModel Insert(PostModel newPost)
        {
            newPost.Id = this.posts.Count + 1;
            this.posts.Add(newPost);
            return newPost;
        }

        public void Update(PostModel updatedPost)
        {
            foreach(PostModel post in posts)
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
using System.Collections.Generic;
using System.Linq;
using WebAPIStarterData;
using WebAPIStarterData.Models;

namespace webAPIStarter.BlogPostService
{
    public class InMemoryDataBaseBlogPostService : IBlogPostService
    {
        private WebAPIStarterContext context;

        public InMemoryDataBaseBlogPostService(WebAPIStarterContext context)
        {
            this.context = context;
        }
        
        public void Delete(BlogPost deletedPost)
        {
            this.context.BlogPosts.Remove(deletedPost);
            this.context.SaveChanges();
        }

        public IList<BlogPost> GetAll()
        {
            return this.context.BlogPosts.ToList();
        }

        public BlogPost GetById(long Id)
        {
            return this.context.BlogPosts.Find(Id);       
        }

        public BlogPost Insert(BlogPost newPost)
        {
            var addedPost = this.context.BlogPosts.Add(newPost);
            this.context.SaveChanges();
            return addedPost.Entity;
        }

        public void Update(BlogPost updatedPost)
        {
            this.context.BlogPosts.Update(updatedPost);
            this.context.SaveChanges();
        }

        // ~InMemoryDataBaseBlogPostService()
        // {
        //     this.context.SaveChanges();
        // }
    }
}
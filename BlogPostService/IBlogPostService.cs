using System.Collections.Generic;
using WebAPIStarterData.Models;

namespace webAPIStarter.BlogPostService
{
    public interface IBlogPostService
    {
       IList<BlogPost> GetAll();
       BlogPost GetById(long Id);
       BlogPost Insert(BlogPost newPost);
       void Update(BlogPost updatedPost);
       void Delete(BlogPost deletedPost);
    }
}
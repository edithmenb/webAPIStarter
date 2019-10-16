using System.Collections.Generic;
using webAPIStarter.Models;

namespace webAPIStarter.BlogPostService
{
    public interface IBlogPostService
    {
       IList<PostModel> GetAll();
       PostModel GetById(long Id);
       PostModel Insert(PostModel newPost);
       void Update(PostModel updatedPost);
       void Delete(PostModel deletedPost);
    }
}
using Entities.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IBlogRepository : IGenericRepository<Blog>
    {
        Task<IEnumerable<Blog>> GetBlogsByAuthorIdAsync(int authorId);
        Task<IEnumerable<Blog>> GetActiveBlogsByAuthorIdAsync(int authorId);

        Task<IEnumerable<Blog>> GetBlogsByCategoryIdAsync(int categoryId);
        Task<IEnumerable<Blog>> GetActiveBlogsByCategoryIdAsync(int categoryId);
        Task<Blog> GetByIdBlogsAsync(int id);
        Task<List<Blog>> GetActiveBlogsAsync();
        Task<IEnumerable<Blog>> GetPassiveBlogsAsync();
        Task<Blog> GetActiveBlogByIdAsync(int Blogid);
        Task<Blog> GetPassiveBlogByIdAsync(int Blogid);

    } 
}
   

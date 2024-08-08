using DataAccess.Abstract;
using DataAccess.concrete;
using Entities.concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.repositories
{
    public class BlogRepository: GenericRepository<Blog>, IBlogRepository
    {
        private readonly Context _context;

        public BlogRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<Blog> GetActiveBlogByIdAsync(int Blogid)
        {
            return await _context.Blogs.FirstOrDefaultAsync(b => b.Id == Blogid && b.IsActive);
        }
        
        public async Task<List<Blog>> GetActiveBlogsAsync()
        {
            return await _context.Blogs.Where(b => b.IsActive)
                .Include(x=>x.Category)
                .Include(y=>y.Author)
                .ToListAsync();
        }

        public async Task<IEnumerable<Blog>> GetActiveBlogsByAuthorIdAsync(int authorId)
        {
            return await _context.Blogs.Where(b => b.AuthorId == authorId && b.IsActive).ToListAsync();
        }

        public async Task<IEnumerable<Blog>> GetActiveBlogsByCategoryIdAsync(int categoryId)
        {
            return await _context.Blogs.Where(b => b.CategoryId == categoryId && b.IsActive)
                .Include(x=>x.Category)
                .Include(y=>y.Author)
                .ToListAsync();
        }

     
        public async Task<IEnumerable<Blog>> GetBlogsByAuthorIdAsync(int authorId)
        {
            return await _context.Blogs.Where(b => b.AuthorId == authorId).ToListAsync();
        }

        public async Task<IEnumerable<Blog>> GetBlogsByCategoryIdAsync(int categoryId)
        {
            return await _context.Blogs.Where(b => b.CategoryId == categoryId).ToListAsync();
        }

        public async Task<Blog> GetPassiveBlogByIdAsync(int Blogid)
        {
            return await _context.Blogs.FirstOrDefaultAsync(b => b.Id == Blogid && !b.IsActive);
        }

        public async Task<IEnumerable<Blog>> GetPassiveBlogsAsync()
        {
            return await _context.Blogs.Where(b => !b.IsActive).ToListAsync();
        }

        public async Task<Blog> GetByIdBlogsAsync(int id)
        {
            return await _context.Blogs.Where(b => b.Id == id)
              .Include(x => x.Category)
              .Include(y => y.Author)
              .Include(z => z.Comments)
             .FirstOrDefaultAsync();
        }
    }
}

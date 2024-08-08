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
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        private Context _context;
        public CommentRepository(Context context) : base(context)
        {
            _context = context;
        }

      
        public async Task<List<Comment>> GetCommentsByBlogIdAsync(int blogId)
        {
            return await _context.Comments
            .Where(c => c.BlogId == blogId && c.ParentCommentId == null)
            .Include(c => c.Replies)
            .Include(c=>c.User)
            .ToListAsync();
        }

        public async Task<List<Comment>> GetRepliesByParentCommentIdAsync(int parentCommentId)
        {
            return await _context.Comments
                                 .Where(c => c.ParentCommentId == parentCommentId)
                                 .Include (c => c.User)
                                 .ToListAsync();
        }

    }
}

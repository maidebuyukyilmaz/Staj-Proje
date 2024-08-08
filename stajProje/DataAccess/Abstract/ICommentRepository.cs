using Entities.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
   public interface ICommentRepository:IGenericRepository<Comment>
    {
        Task<List<Comment>> GetCommentsByBlogIdAsync(int blogId);
        Task<List<Comment>> GetRepliesByParentCommentIdAsync(int parentCommentId);
    }
}

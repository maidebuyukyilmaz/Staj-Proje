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
    public class AuthorAboutRepository : GenericRepository<AuthorAbout>, IAuthorAboutRepository
    {
        private readonly Context _context;
        public AuthorAboutRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<AuthorAbout> GetAboutByAuthorIdAsync(int authorId)
        {
            return await _context.AuthorAbouts.FirstOrDefaultAsync(b => b.AuthorId == authorId);
        }
    }
    
}

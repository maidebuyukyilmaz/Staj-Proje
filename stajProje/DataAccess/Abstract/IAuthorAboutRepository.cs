﻿using Entities.concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IAuthorAboutRepository:IGenericRepository<AuthorAbout>
    {
        Task<AuthorAbout> GetAboutByAuthorIdAsync(int authorId);
    }
}

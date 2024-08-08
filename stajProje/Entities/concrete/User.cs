using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.concrete
{
   public class User:IdentityUser<int>
    {
        public string Name {  get; set; }
        public string Surname { get; set; }
      
       
        public AuthorAbout AuthorAbout { get; set; }
      
        public List<Blog> Blogs { get; set; }
        public List<Comment> Comments { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.concrete
{
   public class AuthorAbout
    {
        public int Id {  get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public int AuthorId { get; set; }
        public User Author { get; set; }
    }
}

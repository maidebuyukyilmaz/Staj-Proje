
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stajProje.UI.DTOs.BlogDtos
{
   public class UpdateBlogdto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
      
        public int AuthorId { get; set; }
    
        public int CategoryId { get; set; }
      
       
    }
}

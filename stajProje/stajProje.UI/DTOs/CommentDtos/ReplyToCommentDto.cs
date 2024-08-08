

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stajProje.UI.DTOs.CommentDtos
{
    public  class ReplyToCommentDto
    {
       public int BlogId { get; set; }
       public string Content { get; set; }
       public int UserId { get; set; }
       public int ParentCommentId { get; set; }
          
      
        
    }
}

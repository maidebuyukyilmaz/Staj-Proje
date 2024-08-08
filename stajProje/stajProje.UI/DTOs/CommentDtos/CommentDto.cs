
using stajProje.UI.DTOs.BlogDtos;
using stajProje.UI.DTOs.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace stajProje.UI.DTOs.CommentDtos
{
   public class CommentDto
    {
        public int CommentId { get; set; }
        public int BlogId { get; set; }
        public string Content { get; set; }
        public int? ParentCommentId { get; set; } // Yanıtın ait olduğu yorum, null ise ana yorum
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }


        public BlogDto Blog { get; set; }
        public CommentDto ParentComment { get; set; } // Yanıtın ait olduğu yorum
        public ICollection<CommentDto> Replies { get; set; } // Yorumun yanıtları
        public UserDto User { get; set; }
    }
}

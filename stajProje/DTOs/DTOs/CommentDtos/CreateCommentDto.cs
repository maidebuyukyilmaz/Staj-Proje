using DTO.DTOs.BlogDtos;
using DTO.DTOs.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOs.CommentDtos
{
    public class CreateCommentDto
    {
        public int BlogId { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
       
    }
}

using DTO.DTOs.CategoryDtos;
using DTO.DTOs.CommentDtos;
using DTO.DTOs.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOs.BlogDtos
{
   public class BlogDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsActive { get; set; }
        public int AuthorId { get; set; }
        public UserDto Author { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
        public List<CommentDto> Comments { get; set; }
        public DateTime? PublishedAt { get; set; }
    }
}

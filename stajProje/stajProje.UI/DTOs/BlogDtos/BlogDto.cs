
using stajProje.UI.DTOs.CategoryDtos;
using stajProje.UI.DTOs.CommentDtos;
using stajProje.UI.DTOs.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace stajProje.UI.DTOs.BlogDtos
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

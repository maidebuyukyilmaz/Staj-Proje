
using stajProje.UI.DTOs.BlogDtos;
using stajProje.UI.DTOs.CommentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace stajProje.UI.DTOs.UserDtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Rol {  get; set; }
        public List<BlogDto> Blogs { get; set; }
        public List<CommentDto> Comments { get; set; }

    }
}

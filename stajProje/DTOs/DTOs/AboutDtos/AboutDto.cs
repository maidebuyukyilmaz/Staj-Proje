using DTO.DTOs.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOs.AboutDtos
{
    public class AboutDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public int AuthorId { get; set; }
        public UserDto Author { get; set; }
    }
}

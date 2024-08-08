using DTO.DTOs.BlogDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOs.CategoryDtos
{
   public class CategoryDto

    {
        public int Id { get; set; }
        public string Name { get; set; }
     
        public List<BlogDto> Blogs { get; set; }

    }
}

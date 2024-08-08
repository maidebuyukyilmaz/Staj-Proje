
using stajProje.UI.DTOs.BlogDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace stajProje.UI.DTOs.CategoryDtos
{

   public class CategoryDto

    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BlogDto> Blogs { get; set; }

    }
}

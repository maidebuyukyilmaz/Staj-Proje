using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOs.BlogDtos
{public  class UpdateBlogActivityDto
    {
        public int Id { get; set; }
       
        public bool IsActive { get; set; }
     
        public DateTime? PublishedAt { get; set; }
    }
}

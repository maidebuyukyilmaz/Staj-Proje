using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stajProje.UI.DTOs.AboutDtos
{
    public class UpdateAboutDto
    {
        public int UserId { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }

    }
}

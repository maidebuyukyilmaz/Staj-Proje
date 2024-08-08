using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTOs.UserDtos
{
    public class UpdateUserRoleDto
    {
        public int UserId { get; set; }
        public string NewRole {  get; set; }
    }
}

using DTO.DTOs.UserDtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterUser(UserRegistrationDto userRegistrationDto);
        Task<bool> ValidateUser(LoginDto loginDto);
        Task<string> CreateToken();
        Task<bool> UpdateUserRole(UpdateUserRoleDto updateUserRoleDto);
        Task<bool> DeleteUser(int userId);
        Task<bool> UpdateUser(UpdateUserDto updateUserDto);
        Task<bool> ChangePassword(ChangePasswordDto changePasswordDto);
        Task<IEnumerable< UserDto>> GetUsersByRoleName(string roleName);
        Task<UserDto> TGetCurrentUserInfo(int id);


    }
}

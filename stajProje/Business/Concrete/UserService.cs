using AutoMapper;
using Business.Abstract;
using DTO.DTOs.UserDtos;
using Entities.concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private User? _user;

        public UserService(UserManager<User> userManager, RoleManager<Role> roleManager, IMapper mapper, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<bool> ChangePassword(ChangePasswordDto changePasswordDto)
        {
            if (changePasswordDto.NewPassword != changePasswordDto.ConfirmNewPassword)
            {
                return false;
            }

            var user = await _userManager.FindByIdAsync(changePasswordDto.UserId.ToString());
            if (user == null)
            {
                return false;
            }

            var result = await _userManager.ChangePasswordAsync(user, changePasswordDto.CurrentPassword, changePasswordDto.NewPassword);
            if (!result.Succeeded)
            {
                return false;
            }

            return true;
        }

        public async Task<string> CreateToken()
        {
            var signinCredentials = GetSigninCredentials();
            var claims = await GetClaims();
            var tokenOptions=GenerateTokenOptions(signinCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        

        public async Task<bool> DeleteUser(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return false;
            }

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                return false;
            }

            return true;
        }

        public async Task<IEnumerable<UserDto>> GetUsersByRoleName(string roleName)
        {
            var usersInRole = await _userManager.GetUsersInRoleAsync(roleName);
            var userDtos = _mapper.Map<List<UserDto>>(usersInRole);
            return userDtos;
        }

        public async Task<IdentityResult> RegisterUser(UserRegistrationDto userRegistrationDto)
        {
            User user = _mapper.Map<User>(userRegistrationDto);
            IdentityResult result = await _userManager.CreateAsync(user, userRegistrationDto.Password);

            if (result.Succeeded)
            {
               

                await _userManager.AddToRoleAsync(user, "user");
              
            }
            return result;
        }

        public async Task<bool> UpdateUser(UpdateUserDto updateUserDto)
        {
            var user = await _userManager.FindByIdAsync(updateUserDto.Id.ToString());
            if (user == null)
            {
                return false;
            }

            _mapper.Map(updateUserDto, user);
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> UpdateUserRole(UpdateUserRoleDto updateUserRoleDto)
        {
            var user = await _userManager.FindByIdAsync(updateUserRoleDto.UserId.ToString());
            if (user == null)
            {
                return false;
            }

            var currentRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, currentRoles);

            if (!await _roleManager.RoleExistsAsync(updateUserRoleDto.NewRole))
            {
                return false;
            }

            await _userManager.AddToRoleAsync(user, updateUserRoleDto.NewRole);
            return true;
        }
        public async Task<UserDto> TGetCurrentUserInfo(int id) 
        {

            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                throw new KeyNotFoundException("Kullanıcı bulunamadı.");
            }

            return _mapper.Map<UserDto>(user);

        }

           
        public async Task<bool> ValidateUser(LoginDto loginDto)
        {
            _user = await _userManager.FindByEmailAsync(loginDto.EMail);
            var result = (_user != null && await _userManager.CheckPasswordAsync(_user, loginDto.Password));
            if (!result) return false;
            return result;
                
        }
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signinCredentials,List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken(
                issuer: jwtSettings["validIssuer"],
                audience: jwtSettings["validAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
                signingCredentials: signinCredentials
                );
            return tokenOptions;
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email,_user.Email)
            };
            var roles =await _userManager.GetRolesAsync(_user);
           foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));   
            }  
           claims.Add(new Claim(ClaimTypes.NameIdentifier,_user.Id.ToString()));
           
            return claims;
        }

        private SigningCredentials GetSigninCredentials()
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettings["secretKey"]);
            var secret =new SymmetricSecurityKey(key);
            return new SigningCredentials(secret,SecurityAlgorithms.HmacSha256);
        }
      
    }
}

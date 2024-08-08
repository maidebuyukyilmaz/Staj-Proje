using Business.Abstract;
using DTO.DTOs.UserDtos;
using Entities.concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace stajProje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService _userService) : ControllerBase
    {

     

        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserRegistrationDto userRegistrationDto)
        {
            var result = await _userService.RegisterUser(userRegistrationDto);

            if (result.Succeeded)
            {
                return Ok("User registered successfully.");
            }

           
            return BadRequest(new { Errors = result.Errors.Select(e => e.Description) });
        }

       
        [HttpPost("update-role")]
        public async Task<IActionResult> UpdateUserRole([FromBody] UpdateUserRoleDto updateUserRole)
        {
            var result = await _userService.UpdateUserRole(updateUserRole);

            if (result)
            {
                return Ok("User updated successfully.");
            }


            return BadRequest();
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("delete-user/{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {

            var result = await _userService.DeleteUser(userId);

            if (result)
            {
                return Ok("User deleted successfully.");
            }


            return BadRequest();
        }
     
        [HttpPut("update-user")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto updateUserDto)
        {
            var result = await _userService.UpdateUser(updateUserDto);

            if (result)
            {
                return Ok("User updated successfully.");
            }


            return BadRequest();
        }
        [Authorize(Roles ="user, author,admin")]
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
        {
             var result = await _userService.ChangePassword(changePasswordDto);

            if (result)
            {
                return Ok("User password changed successfully.");
            }


            return BadRequest();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] LoginDto loginDto)
        {
            if(!await _userService.ValidateUser(loginDto))
                return Unauthorized();
          
            return Ok(
                new
                {
                    Token=await _userService.CreateToken()
                }
                );
        }
      
        [HttpGet("by-role/{roleName}")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsersByRoleName(string roleName)
        {
            var userDtos = await _userService.GetUsersByRoleName(roleName);
            return Ok(userDtos);
        }


        [HttpGet("current/{id}")]
        public async Task<IActionResult> GetCurrentUserInfo(int id)
        {
            var userDtos = await _userService.TGetCurrentUserInfo(id);
            return Ok(userDtos);
        }
    }
}

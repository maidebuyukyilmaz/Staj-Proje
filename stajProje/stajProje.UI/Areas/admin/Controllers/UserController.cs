using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using stajProje.UI.DTOs.UserDtos;
using stajProje.UI.Helpers;
using System.Text;

namespace stajProje.UI.Areas.admin.Controllers
{
    [Area("admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class UserController : Controller
    {
        private readonly HttpClient _client;
        public UserController()
        {
            _client = HttpClientInstance.CreateClient(); ;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _client.GetAsync("Users/by-role/user");
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error retrieving users");
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<List<UserDto>>(jsonData);
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _client.DeleteAsync($"Users/delete-user/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error deleting user");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateUserRoleDto updateUserRoleDto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(updateUserRoleDto), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("Users/update-role", content);
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error updating user role");
            }

            return RedirectToAction("Index");
        }
    }
}

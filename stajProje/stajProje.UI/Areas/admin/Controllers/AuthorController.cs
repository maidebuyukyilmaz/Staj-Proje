using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using stajProje.UI.DTOs.AboutDtos;
using stajProje.UI.DTOs.UserDtos;
using stajProje.UI.Helpers;
using System.Text;

namespace stajProje.UI.Areas.admin.Controllers
{
    [Area("admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class AuthorController : Controller
    {
        private readonly HttpClient _client;
        public AuthorController()
        {
            _client = HttpClientInstance.CreateClient(); ;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _client.GetAsync("Users/by-role/author");
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error retrieving authors");
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var authors = JsonConvert.DeserializeObject<List<UserDto>>(jsonData);
            return View(authors);
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _client.GetAsync($"Abouts/by-author/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error retrieving author details");
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var about = JsonConvert.DeserializeObject<AboutDto>(jsonData);
            return View(about);
        }

        
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _client.DeleteAsync($"Users/delete-user/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error deleting author");
            }

            return RedirectToAction("Index");
        }

       
        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateUserRoleDto updateUserRoleDto)
        {
            if (!ModelState.IsValid)
            {
                // Model state invalid
                return BadRequest("Invalid data");
            }

            var content = new StringContent(JsonConvert.SerializeObject(updateUserRoleDto), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("Users/update-role", content);

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error updating author role");
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            var response = await _client.DeleteAsync($"Abouts/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error deleting about");
            }

            return RedirectToAction("Index");
        }
    }
}


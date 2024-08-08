using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using stajProje.UI.DTOs.AboutDtos;
using stajProje.UI.DTOs.BlogDtos;
using stajProje.UI.DTOs.CategoryDtos;
using stajProje.UI.DTOs.UserDtos;
using stajProje.UI.Helpers;

namespace stajProje.UI.Areas.user.Controllers
{
    [Authorize]
    [Area("user")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class AuthorController : Controller
    {
        private readonly HttpClient _client;
        public AuthorController()
        {
            _client = HttpClientInstance.CreateClient(); ;
        }
        public async Task< IActionResult> Index(string rolName)
        {
       
            var response = await _client.GetAsync($"Users/by-role/{rolName}");
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error retrieving blog details");
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<AboutDto>(jsonData);
            return View(user);
        }

        public async Task<IActionResult> AuthorBlog(int authorId)
        {
       
            var response = await _client.GetAsync($"Blogs/active/by-author/{authorId}");
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error retrieving blog details");
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var about = JsonConvert.DeserializeObject<AboutDto>(jsonData);
            return View(about);
        }
       
    }
}

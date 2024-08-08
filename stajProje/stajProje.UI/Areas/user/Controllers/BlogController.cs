using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using stajProje.UI.Areas.admin.Controllers;
using stajProje.UI.DTOs.BlogDtos;
using stajProje.UI.DTOs.CategoryDtos;
using stajProje.UI.Helpers;

namespace stajProje.UI.Areas.user.Controllers
{
    [Authorize]
    [Area("user")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class BlogController : Controller
    {
        private readonly HttpClient _client;
        public BlogController()
        {
            _client = HttpClientInstance.CreateClient(); ;
        }
        public async Task<IActionResult> Index()
        {
        
            var response = await _client.GetAsync("Blogs/active");
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error retrieving blogs");
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var blogs = JsonConvert.DeserializeObject<List<BlogDto>>(jsonData);
            return View(blogs);

            
        }
        public async Task<IActionResult> Details(int id)
        {
          
            var response = await _client.GetAsync($"Blogs/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error retrieving blog details");
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var blog = JsonConvert.DeserializeObject<BlogDto>(jsonData);
            return View(blog);
        }
        public async Task<IActionResult> BlogsByCategory(int categoryId)
        {
         
            var response = await _client.GetAsync($"Blogs/active/by-category/{categoryId}");
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error retrieving blogs by category");
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var blogs = JsonConvert.DeserializeObject<List<BlogDto>>(jsonData);
            return View("Index", blogs);
        }
      
      
    }
}

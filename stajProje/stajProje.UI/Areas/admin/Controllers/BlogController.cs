using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using stajProje.UI.DTOs.BlogDtos;
using stajProje.UI.Helpers;
using System.Text;

namespace stajProje.UI.Controllers
{

    [Area("admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class BlogController : Controller
    {
        private readonly HttpClient _client;
        public BlogController()
        {
            _client =  HttpClientInstance.CreateClient();;
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
        [HttpPost]
        public async Task<IActionResult> UpdateActivity(UpdateBlogActivityDto updateBlogActivityDto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(updateBlogActivityDto), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("Blogs/update-activity", content);
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error updating blog activity");
            }

            return RedirectToAction("Details", new { id = updateBlogActivityDto.Id });
        }
        public async Task<IActionResult> ActiveBlogs()
        {
            var response = await _client.GetAsync("Blogs/active");
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error retrieving active blogs");
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var blogs = JsonConvert.DeserializeObject<List<BlogDto>>(jsonData);
            return View(blogs);
        }
        public async Task<IActionResult> PassiveBlogs()
        {
            var response = await _client.GetAsync("Blogs/passive");
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error retrieving passive blogs");
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var blogs = JsonConvert.DeserializeObject<List<BlogDto>>(jsonData);
            return View(blogs);
        }
    }
}

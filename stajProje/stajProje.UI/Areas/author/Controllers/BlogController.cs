using Microsoft.AspNetCore.Mvc;
using stajProje.UI.DTOs.BlogDtos;
using stajProje.UI.Helpers;
using System.Net.Http;
using System.Text;

namespace stajProje.UI.Areas.author.Controllers
{
    [Area("author")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class BlogController : Controller
    {
        private readonly HttpClient _client;
        public BlogController()
        {
            _client = HttpClientInstance.CreateClient(); ;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogDto createBlogDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createBlogDto);
            }

            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(createBlogDto), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/blogs/create", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home", new { area = "author" });
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            ModelState.AddModelError(string.Empty, responseContent);

            return View(createBlogDto);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using stajProje.UI.DTOs.BlogDtos;
using stajProje.UI.DTOs.UserDtos;
using stajProje.UI.Helpers;
using stajProje.UI.Models;
using System.Diagnostics;
using System.Text;

namespace stajProje.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _client;
       
         
        
        public HomeController()
        {
          
            _client = HttpClientInstance.CreateClient(); ;
        }

        public IActionResult Index()
        {
            

            return View();
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

    }
}

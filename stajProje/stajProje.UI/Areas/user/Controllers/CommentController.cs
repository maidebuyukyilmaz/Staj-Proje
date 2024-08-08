using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using stajProje.UI.DTOs.CommentDtos;
using stajProje.UI.Helpers;
using System.ComponentModel.Design;
using System.Text;
using System.Xml.Linq;

namespace stajProje.UI.Areas.user.Controllers
{
    [Authorize]
    [Area("user")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class CommentController : Controller
    {
        private readonly HttpClient _client;
        public CommentController()
        {
            _client = HttpClientInstance.CreateClient(); ;
        }
        public async Task<IActionResult> CommentsByBlogId(int id)
        {
            var response = await _client.GetAsync($"Comments/by-blog/{id}");


            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var comments = JsonConvert.DeserializeObject<List<CommentDto>>(jsonData);


                return RedirectToAction("Details", "Blog", comments);
            }
            return StatusCode((int)response.StatusCode, "Error retrieving comments");
        }
        public async Task<IActionResult> RepliesByCommentId (int id)
        {
            var response = await _client.GetAsync($"replies/{id}");

          
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var replies = JsonConvert.DeserializeObject<List<CommentDto>>(jsonData);

              
                return RedirectToAction("Details", "Blog", replies);
            }

            return StatusCode((int)response.StatusCode, "Error retrieving replies");

        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentDto createCommentDto)
        {
            var jsonContent = JsonConvert.SerializeObject(createCommentDto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

          
            var response = await _client.PostAsync("Comments", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Details", "Blog", new { id = createCommentDto.BlogId });
            }

            return View(createCommentDto);
        }
    }
}

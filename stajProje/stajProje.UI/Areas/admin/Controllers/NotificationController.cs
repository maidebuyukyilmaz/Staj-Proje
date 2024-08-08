using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using stajProje.UI.DTOs.ContactDtos;
using stajProje.UI.Helpers;

namespace stajProje.UI.Areas.admin.Controllers
{
    [Area("admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class NotificationController : Controller
    {
        private readonly HttpClient _client;
        public NotificationController()
        {
            _client = HttpClientInstance.CreateClient();

        }

        public async Task<IActionResult> Index()
        {
            var response = await _client.GetAsync("Contacts");
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error retrieving contacts");
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var contacts = JsonConvert.DeserializeObject<List<ContactDto>>(jsonData);
            return View(contacts);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _client.DeleteAsync($"Contacts/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error deleting contact");
            }

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int id)
        {
            var response = await _client.GetAsync($"Contacts/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error retrieving contact details");
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var blog = JsonConvert.DeserializeObject<ContactDto>(jsonData);
            return View(blog);
        }
    }

}

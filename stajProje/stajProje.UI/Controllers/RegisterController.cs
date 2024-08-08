using Microsoft.AspNetCore.Mvc;
using stajProje.UI.DTOs.UserDtos;
using stajProje.UI.Helpers;
using System.Net.Http;
using System.Text;

namespace stajProje.UI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly HttpClient _client;
        public RegisterController()
        {
            _client = HttpClientInstance.CreateClient(); ;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegistrationDto userRegistrationDto)
        {
            if (!ModelState.IsValid)
            {
                return View(userRegistrationDto);
            }

            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(userRegistrationDto), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("Users", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("RegisterSuccess");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var errors = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string[]>>(responseContent);
            foreach (var error in errors["Errors"])
            {
                ModelState.AddModelError("", error);
            }

            return View(userRegistrationDto);
        }

        public IActionResult RegisterSuccess()
        {
            return View();
        }
    }
}

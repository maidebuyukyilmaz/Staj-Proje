using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using stajProje.UI.DTOs.ContactDtos;
using stajProje.UI.Helpers;
using System.Text;

namespace stajProje.UI.Controllers
{
    public class ContactController : Controller
    {
        private readonly HttpClient _client;
        public ContactController()
        {
            _client = HttpClientInstance.CreateClient(); ;
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            var jsonContent = JsonConvert.SerializeObject(createContactDto);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("Contact", content);

            if (response.IsSuccessStatusCode)
            {
                return View(response);
            }
            return BadRequest();
        }
    }
}
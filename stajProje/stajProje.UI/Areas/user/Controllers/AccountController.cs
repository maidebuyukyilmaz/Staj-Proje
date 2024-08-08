using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using stajProje.UI.DTOs.UserDtos;
using stajProje.UI.Helpers;
using stajProje.UI.Services;
using System.Net.Http.Headers;

namespace stajProje.UI.Areas.user.Controllers
{
    [Authorize]
    [Area("user")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class AccountController : Controller
    {

        private readonly HttpClient _client;
        private readonly ILoginService _loginService;
        public AccountController(ILoginService loginService)
        {
            _client = HttpClientInstance.CreateClient(); 
            _loginService= loginService;
        }

        public async Task<IActionResult> Account()
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "blogtoken")?.Value;

            var id = _loginService.GetUserId;
          
            if(token != null) { 
            var response = await _client.GetAsync($"current/{id}");
            if(response.IsSuccessStatusCode)
            {
                var jsonData=await response.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<UserDto>>(jsonData);
                return View(values);
            }
            }
            return View();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using stajProje.UI.Helpers;

namespace stajProje.UI.Areas.user.Controllers
{
    [Authorize]
    [Area("user")]
    [Route("[area]/[controller]/[action]/{id?}")]
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
    }
}

using Microsoft.AspNetCore.Mvc;

namespace stajProje.UI.Areas.author.Controllers
{
    [Area("author")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

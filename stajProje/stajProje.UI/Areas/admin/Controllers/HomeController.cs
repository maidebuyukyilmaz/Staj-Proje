using Microsoft.AspNetCore.Mvc;

namespace stajProje.UI.Areas.admin.Controllers
{
    [Area("admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

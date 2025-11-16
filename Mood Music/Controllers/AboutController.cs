using Microsoft.AspNetCore.Mvc;

namespace Mood_Music.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mood_Music.Models;

namespace Mood_Music.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

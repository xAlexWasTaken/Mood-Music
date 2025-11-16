using Microsoft.AspNetCore.Mvc;
using Mood_Music.Models;

namespace Mood_Music.Controllers
{
    public class DiscoverController : Controller
    {
        private readonly IMusicProvider _musicProvider;

        public DiscoverController(IMusicProviderFactory factory)
        {
            _musicProvider = factory.Create();
        }

        public async Task<IActionResult> Index(string mood = "happy")
        {
            var tracks = await _musicProvider.SearchTracksByMoodAsync(mood);
            return View(tracks);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Mood_Music.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mood_Music.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly AppDbContext _context;

        public FavoritesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Favorite favorite)
        {
            if (ModelState.IsValid)
            {
                var exists = await _context.Favorites
                    .AnyAsync(f => f.Title == favorite.Title && f.Artist == favorite.Artist);

                if (!exists)
                {
                    _context.Favorites.Add(favorite);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Index", "Discover");
        }

        public async Task<IActionResult> Index()
        {
            var favorites = await _context.Favorites.ToListAsync();

            return View(favorites);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(int id)
        {
            var favorite = await _context.Favorites.FindAsync(id);
            if (favorite != null)
            {
                _context.Favorites.Remove(favorite);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

    }
}

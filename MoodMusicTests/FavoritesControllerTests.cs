using System.Linq;
using System.Threading.Tasks;
using Mood_Music.Controllers;
using Mood_Music.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;


namespace MoodMusicTests
{
    public class FavoritesControllerTests
    {
        private AppDbContext CreateInMemoryDb()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "FavoritesTestDB_" + System.Guid.NewGuid())
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public async Task Add_WhenFavoriteIsValid_SavesToDatabase()
        {
            // Arrange
            var context = CreateInMemoryDb();
            var controller = new FavoritesController(context);

            var favorite = new Favorite
            {
                Title = "Test Song",
                Artist = "Test Artist",
                Album = "Test Album",
                PreviewUrl = "test.mp3",
                ArtworkUrl = "test.jpg"
            };

            // Act
            await controller.Add(favorite);

            // Assert
            Assert.Equal(1, context.Favorites.Count());
        }

        [Fact]
        public async Task Add_WhenFavoriteAlreadyExists_DoesNotDuplicate()
        {
            // Arrange
            var context = CreateInMemoryDb();
            var controller = new FavoritesController(context);

            var favorite = new Favorite
            {
                Title = "Test Song",
                Artist = "Test Artist",
                Album = "Test Album",
                PreviewUrl = "test.mp3",
                ArtworkUrl = "test.jpg"
            };

            await controller.Add(favorite);
            await controller.Add(favorite); // tries to create a duplicate

            // Assert
            Assert.Equal(1, context.Favorites.Count());
        }

        [Fact]
        public async Task Add_WhenSuccessful_RedirectsToIndex()
        {
            // Arrange
            var context = CreateInMemoryDb();
            var controller = new FavoritesController(context);

            var favorite = new Favorite
            {
                Title = "Test Song",
                Artist = "Test Artist",
                Album = "Test Album",
                PreviewUrl = "test.mp3",
                ArtworkUrl = "test.jpg"
            };

            // Act
            var result = await controller.Add(favorite);

            // Assert
            var redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirect.ActionName);
        }
    }
}

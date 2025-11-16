using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mood_Music.Controllers;
using Mood_Music.Models;
using MoodMusicTests.Fakes;

namespace MoodMusicTests
{
    public class DiscoverControllerTests
    {
        [Fact]
        public async Task Index_WhenTracksExist_ReturnsViewWithTracks()
        {
            // Arrange
            var fakeProvider = new FakeMusicProvider();
            fakeProvider.TracksToReturn.Add(new Track { Title = "Test Song", Artist = "Test Artist" });

            var fakeFactory = new FakeMusicProviderFactory(fakeProvider);
            var controller = new DiscoverController(fakeFactory);

            // Act
            var result = await controller.Index("happy");

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Track>>(viewResult.Model);
            Assert.Single(model);
        }

        [Fact]
        public async Task Index_WhenNoTracksFound_ReturnsEmptyList()
        {
            // Arrange
            var fakeProvider = new FakeMusicProvider(); // returns an empty list
            var fakeFactory = new FakeMusicProviderFactory(fakeProvider);
            var controller = new DiscoverController(fakeFactory);

            // Act
            var result = await controller.Index("unknown");

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Track>>(viewResult.Model);
            Assert.Empty(model);
        }
    }
}

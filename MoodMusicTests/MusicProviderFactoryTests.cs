using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mood_Music.Models;
using System.Net.Http;
using MoodMusicTests.Fakes;

namespace MoodMusicTests
{
    public class MusicProviderFactoryTests
    {
        [Fact]
        public void Create_WhenCalled_ReturnsIMusicProvider()
        {
            // Arrange
            var fakeHttpFactory = new FakeHttpClientFactory();
            var factory = new MusicProviderFactory(fakeHttpFactory);

            // Act
            var provider = factory.Create();

            // Assert
            Assert.IsAssignableFrom<IMusicProvider>(provider);
        }

        [Fact]
        public void Create_WhenCalled_ReturnsDeezerMusicProvider()
        {
            // Arrange
            var fakeHttpFactory = new FakeHttpClientFactory();
            var factory = new MusicProviderFactory(fakeHttpFactory);

            // Act
            var provider = factory.Create();

            // Assert
            Assert.IsType<DeezerMusicProvider>(provider);
        }
    }
}

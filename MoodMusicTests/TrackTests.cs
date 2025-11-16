using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mood_Music.Models;

namespace MoodMusicTests
{
    public class TrackTests
    {
        [Fact]
        public void Track_WhenAssignedProperties_StoresValuesCorrectly()
        {
            var track = new Track
            {
                Title = "Song Title",
                Artist = "Artist Name",
                Album = "Album Name",
                PreviewUrl = "test.mp3",
                ArtworkUrl = "image.jpg"
            };

            Assert.Equal("Song Title", track.Title);
            Assert.Equal("Artist Name", track.Artist);
            Assert.Equal("Album Name", track.Album);
            Assert.Equal("test.mp3", track.PreviewUrl);
            Assert.Equal("image.jpg", track.ArtworkUrl);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mood_Music.Models;

namespace MoodMusicTests.Fakes
{
    public class FakeMusicProvider : IMusicProvider
    {
        public List<Track> TracksToReturn { get; set; } = new List<Track>();

        public Task<List<Track>> SearchTracksByMoodAsync(string mood, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(TracksToReturn);
        }
    }
}

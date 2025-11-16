using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mood_Music.Models
{
    public interface IMusicProvider
    {
        Task<List<Track>> SearchTracksByMoodAsync(string mood, CancellationToken cancellationToken = default);
    }
}

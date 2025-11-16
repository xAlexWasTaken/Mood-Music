using System.Net.Http;
using System.Text;
using System.Text.Json;
using static Mood_Music.Models.DeezerApiModels;

namespace Mood_Music.Models
{
    public sealed class DeezerMusicProvider : IMusicProvider
    {
        private readonly HttpClient _http;
        private readonly JsonSerializerOptions _json;

        public DeezerMusicProvider(HttpClient httpClient, JsonSerializerOptions? jsonOptions = null)
        {
            _http = httpClient;
            _json = jsonOptions ?? new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<List<Track>> SearchTracksByMoodAsync(string mood, CancellationToken cancellationToken = default)
        {
            var query = mood?.Trim().ToLowerInvariant() switch
            {
                "happy" => "upbeat pop",
                "chill" => "lofi beats",
                "focus" => "instrumental ambient",
                "sad" => "sad",
                "party" => "disco",
                _ => string.IsNullOrWhiteSpace(mood) ? "popular" : mood.Trim()
            };

            var encoded = Uri.EscapeDataString(query);
            var requestUri = _http.BaseAddress is not null
                ? new Uri($"search?q={encoded}", UriKind.Relative)
                : new Uri($"https://api.deezer.com/search?q={encoded}", UriKind.Absolute);

            using var req = new HttpRequestMessage(HttpMethod.Get, requestUri);

            using var resp = await _http.SendAsync(
                req,
                HttpCompletionOption.ResponseHeadersRead,
                cancellationToken
            ).ConfigureAwait(false);

            if (!resp.IsSuccessStatusCode)
            {
                return new List<Track>();
            }

            await using var stream = await resp.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
            var dto = await JsonSerializer.DeserializeAsync<DeezerSearchDto>(stream, _json, cancellationToken)
                      .ConfigureAwait(false);

            if (dto is null || dto.Data.Count == 0)
                return new List<Track>();

            var tracks = dto.Data
                .Where(d => !string.IsNullOrWhiteSpace(d.Preview))
                .Select(d => new Track
                {
                    Id = d.Id.ToString(),
                    Provider = "deezer",
                    Title = d.Title ?? string.Empty,
                    Artist = d.Artist?.Name ?? string.Empty,
                    Album = d.Album?.Title ?? string.Empty,
                    PreviewUrl = d.Preview ?? string.Empty,
                    ArtworkUrl = d.Album?.CoverMedium ?? string.Empty
                })
                .Take(30)
                .ToList();

            return tracks;
        }
    }
}

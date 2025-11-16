using System.Text.Json.Serialization;

namespace Mood_Music.Models
{
    public class DeezerApiModels
    {
        public sealed class DeezerSearchDto
        {
            [JsonPropertyName("data")]
            public List<DeezerTrackDto> Data { get; set; } = new List<DeezerTrackDto>();
        }

        public sealed class DeezerTrackDto
        {
            [JsonPropertyName("id")]
            public long Id { get; set; }

            [JsonPropertyName("title")]
            public string? Title { get; set; }

            [JsonPropertyName("preview")]
            public string? Preview { get; set; }

            [JsonPropertyName("artist")]
            public DeezerArtistDto? Artist { get; set; }

            [JsonPropertyName("album")]
            public DeezerAlbumDto? Album { get; set; }
        }

        public sealed class DeezerArtistDto
        {
            [JsonPropertyName("name")]
            public string? Name { get; set; }
        }

        public sealed class DeezerAlbumDto
        {
            [JsonPropertyName("title")]
            public string? Title { get; set; }

            [JsonPropertyName("cover_medium")]
            public string? CoverMedium { get; set; }
        }
    }
}

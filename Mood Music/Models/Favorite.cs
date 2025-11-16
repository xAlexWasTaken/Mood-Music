namespace Mood_Music.Models
{
    public class Favorite
    {
        public int Id { get; set; } 
        public string SessionId { get; set; } = string.Empty;

        public string TrackId { get; set; } = string.Empty;
        public string Provider { get; set; } = "deezer";
        public string Title { get; set; } = string.Empty;
        public string Artist { get; set; } = string.Empty;
        public string Album { get; set; } = string.Empty;
        public string PreviewUrl { get; set; } = string.Empty; 
        public string ArtworkUrl { get; set; } = string.Empty;

        public DateTimeOffset DateTimeOffset { get; set; } = DateTimeOffset.UtcNow;

    }
}

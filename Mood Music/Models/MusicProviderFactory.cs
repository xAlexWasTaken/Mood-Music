using System.Net.Http;

namespace Mood_Music.Models
{
    public sealed class MusicProviderFactory : IMusicProviderFactory
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MusicProviderFactory(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IMusicProvider Create()
        {
            var client = _httpClientFactory.CreateClient("deezer");
            return new DeezerMusicProvider(client);
        }
    }
}

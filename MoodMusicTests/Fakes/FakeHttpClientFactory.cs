using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodMusicTests.Fakes;

// just returns a simple httpclient for testing
public class FakeHttpClientFactory : IHttpClientFactory
{
    public HttpClient Client { get; set; } = new HttpClient();

    public HttpClient CreateClient(string name)
    {

        return Client;
    }
}

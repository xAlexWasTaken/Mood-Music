using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mood_Music.Models;

namespace MoodMusicTests.Fakes
{
    public class FakeMusicProviderFactory : IMusicProviderFactory
    {
        private readonly IMusicProvider _provider;

        public FakeMusicProviderFactory(IMusicProvider provider)
        {
            _provider = provider;
        }

        public IMusicProvider Create() => _provider;
    }
}

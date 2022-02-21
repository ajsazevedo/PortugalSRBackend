using PortugalSRBackend.Core.Interfaces.Services;
using PortugalSRBackend.Core.Interfaces.Services.HackerNews;
using PortugalSRBackend.Domain.HackerNews;

namespace PortugalSRBackend.Application.Services
{
    public class StoryService : HackerNewsService, IStoryService
    {
        public IEnumerable<Story> GetBest20()
        {
            throw new NotImplementedException();
        }
    }
}

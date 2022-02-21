using PortugalSRBackend.Core.Interfaces.Services.HackerNews;
using PortugalSRBackend.Domain.HackerNews;

namespace PortugalSRBackend.Core.Interfaces.Services
{
    public interface IStoryService : IHackerNewsService
    {
        IEnumerable<Story> GetBest20();
    }
}

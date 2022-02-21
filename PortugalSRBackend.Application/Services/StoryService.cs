using Microsoft.Extensions.Options;
using PortugalSRBackend.Core.Interfaces.Services;
using PortugalSRBackend.Core.Interfaces.Services.HackerNews;
using PortugalSRBackend.Core.Objects;
using PortugalSRBackend.Domain.HackerNews;

namespace PortugalSRBackend.Application.Services
{
    public class StoryService : HackerNewsService, IStoryService
    {
        public StoryService(IOptions<HackerNewsSetup> options) : base(options)
        {
        }

        public async Task<IEnumerable<Story>> GetBest20Async()
        {
            var storiesToTake = 20;
            var bestStoriesIds = await GetBestStoriesAsync(storiesToTake);
            var bestStories = new List<Story>();

            foreach (var id in bestStoriesIds)
            {
                bestStories.Add(await GetStory(id));
            }
            return bestStories.OrderByDescending(x => x.Score);
        }
    }
}

using Microsoft.Extensions.Options;
using PortugalSRBackend.Application.Services.Base;
using PortugalSRBackend.Application.WebRequest;
using PortugalSRBackend.Core.Objects;
using PortugalSRBackend.Domain.HackerNews;

namespace PortugalSRBackend.Core.Interfaces.Services.HackerNews
{
    public class HackerNewsService : BaseService, IHackerNewsService
    {
        protected readonly HackerNewsSetup _setup;

        public HackerNewsService(IOptions<HackerNewsSetup> options)
        {
            _setup = options.Value;
        }

        private HttpClient GetClient()
        {
            return RequestEngine.CreateClient(_setup.BaseUrl);
        }

        protected async Task<IEnumerable<int>> GetBestStoriesAsync(int storiesToTake)
        {
            var parameters = "beststories.json";

            var result = await RequestEngine.ExecuteRequestAsync<IEnumerable<int>>(GetClient(), parameters);

            return result.Take(storiesToTake);
        }

        protected async Task<Story> GetStory(int id)
        {
            var parameters = $"item/{id}.json";

            return await RequestEngine.ExecuteRequestAsync<Story>(GetClient(), parameters);
        }
    }
}

using PortugalSRBackend.Application.Services.Base;

namespace PortugalSRBackend.Core.Interfaces.Services.HackerNews
{
    public class HackerNewsService : BaseService, IHackerNewsService
    {
        private readonly string _hackerNewsUrl;

        public HackerNewsService()
        {
            _hackerNewsUrl = "https://hacker-news.firebaseio.com/v0/";
        }

        protected void Connect()
        {

        }
    }
}

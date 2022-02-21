using System.Net.Http.Headers;

namespace PortugalSRBackend.Application.WebRequest
{
    public static class RequestEngine
    {
        public static HttpClient CreateClient(string url)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(url)
            };

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        public static async Task<TEntity> ExecuteRequestAsync<TEntity>(HttpClient client, string urlParameters)
        {
            var response = await client.GetAsync(urlParameters);

            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var dataObjects = response.Content.ReadAsAsync<TEntity>().Result;
                return dataObjects;
            }
            else
            {
                throw new Exception("Not possible to connect to firebase.");
            }
        }
    }
}

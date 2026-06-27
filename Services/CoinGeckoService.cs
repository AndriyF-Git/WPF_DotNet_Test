using System.Net.Http;
using System.Threading.Tasks;

namespace WPF_DotNet_Test.Services
{
    public class CoinGeckoService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CoinGeckoService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetTopCoinsAsync()
        {
            var client = _httpClientFactory.CreateClient("CoinGecko");
            var response = await client.GetAsync("coins/markets?vs_currency=usd&per_page=5");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}

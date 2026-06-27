using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WPF_DotNet_Test.Models;

namespace WPF_DotNet_Test.Services
{
    public class CoinGeckoService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CoinGeckoService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public async Task<List<Coin>> GetTopCoinsAsync()
        {
            var client = _httpClientFactory.CreateClient("CoinGecko");
            var response = await client.GetAsync("coins/markets?vs_currency=usd&per_page=5");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Coin>>(jsonResponse, _jsonOptions) ?? new List<Coin>();
        }
    }
}

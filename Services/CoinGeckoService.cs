using System.Collections.Generic;
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

        public async Task<List<Coin>> GetTopCoinsAsync(int perPage = 50, string? ids = null)
        {
            var client = _httpClientFactory.CreateClient("CoinGecko");
            var url = $"coins/markets?vs_currency=usd&order=market_cap_desc&per_page={perPage}&sparkline=false";
            if (!string.IsNullOrWhiteSpace(ids))
                url += $"&ids={ids}";

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Coin>>(jsonResponse, _jsonOptions) ?? new List<Coin>();
        }

        public async Task<List<Ticker>> GetCoinTickersAsync(string coinId)
        {
            var client = _httpClientFactory.CreateClient("CoinGecko");
            var response = await client.GetAsync($"coins/{coinId}/tickers");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<TickersResponse>(jsonResponse, _jsonOptions);
            return result?.Tickers ?? new List<Ticker>();
        }

        public async Task<List<SearchCoin>> SearchCoinsAsync(string query)
        {
            var client = _httpClientFactory.CreateClient("CoinGecko");
            var response = await client.GetAsync($"search?query={Uri.EscapeDataString(query)}");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<SearchResult>(jsonResponse, _jsonOptions);
            return result?.Coins ?? new List<SearchCoin>();
        }
    }
}

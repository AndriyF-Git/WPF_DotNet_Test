using System.Text.Json.Serialization;

namespace WPF_DotNet_Test.Models
{
    public class SearchCoin
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("symbol")]
        public string? Symbol { get; set; }

        [JsonPropertyName("thumb")]
        public string? Thumb { get; set; }

        [JsonPropertyName("market_cap_rank")]
        public int? MarketCapRank { get; set; }
    }
}

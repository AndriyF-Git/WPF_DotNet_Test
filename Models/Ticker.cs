using System.Text.Json.Serialization;

namespace WPF_DotNet_Test.Models
{
    public class Ticker
    {
        [JsonPropertyName("market")]
        public TickerMarket? Market { get; set; }

        [JsonPropertyName("last")]
        public decimal Last { get; set; }

        [JsonPropertyName("volume")]
        public decimal Volume { get; set; }
    }

    public class TickerMarket
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}

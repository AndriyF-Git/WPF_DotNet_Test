using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WPF_DotNet_Test.Models
{
    public class TickersResponse
    {
        [JsonPropertyName("tickers")]
        public List<Ticker> Tickers { get; set; } = new();
    }
}

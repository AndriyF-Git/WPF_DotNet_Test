using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WPF_DotNet_Test.Models
{
    public class Coin : CoinBase
    {
        [JsonPropertyName("current_price")]
        public decimal CurrentPrice { get; set; }

        [JsonPropertyName("price_change_percentage_24h")]
        public double PriceChangePercentage24h { get; set; }

        [JsonPropertyName("market_cap")]
        public decimal MarketCap { get; set; }
    }
}

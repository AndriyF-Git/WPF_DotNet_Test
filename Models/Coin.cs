using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace WPF_DotNet_Test.Models
{
    public class Coin
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Symbol { get; set; }
        public decimal CurrentPrice { get; set; }
        public double PriceChangePercentage24h { get; set; }
        public decimal MarketCap { get; set; }
    }
}

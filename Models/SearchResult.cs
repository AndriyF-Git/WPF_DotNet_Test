using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WPF_DotNet_Test.Models
{
    public class SearchResult
    {
        [JsonPropertyName("coins")]
        public List<SearchCoin> Coins { get; set; } = new();
    }
}

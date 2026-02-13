using System.Text.Json.Serialization;

namespace EdamamClient.Models
{
    public class EdamamRecipeResponse
    {

        [JsonPropertyName("from")]
        public int From { get; set; }

        [JsonPropertyName("to")]
        public int To { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("_links")]
        public PagingLinks Links { get; set; } = default!;
        [JsonPropertyName("hits")]
        public List<Hit> Hits { get; set; } = [];
    }
}

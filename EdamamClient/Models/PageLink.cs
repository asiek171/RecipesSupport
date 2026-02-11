using System.Text.Json.Serialization;

namespace EdamamClient.Models
{
    public class PageLink
    {
        [JsonPropertyName("href")]
        public string Href { get; set; } = default!;

        [JsonPropertyName("title")]
        public string Title { get; set; } = default!;
    }
}

using System.Text.Json.Serialization;

namespace EdamamClient.Models
{
    public class HitLinks
    {
        [JsonPropertyName("self")]
        public Link Self { get; set; } = default!;
    }

    public class Link
    {
        [JsonPropertyName("href")]
        public string Href { get; set; } = default!;

        [JsonPropertyName("title")]
        public string Title { get; set; } = default!;
    }
}

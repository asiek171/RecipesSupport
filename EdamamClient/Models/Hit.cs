using System.Text.Json.Serialization;

namespace EdamamClient.Models
{
    public class Hit
    {

        [JsonPropertyName("recipe")]
        public Recipe Recipe { get; set; } = default!;

        [JsonPropertyName("_links")]
        public HitLinks Links { get; set; } = default!;
    }
}

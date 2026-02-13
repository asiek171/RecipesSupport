using System.Text.Json.Serialization;

namespace EdamamClient.Models
{
    public class PagingLinks
    {
        [JsonPropertyName("next")]
        public PageLink? Next { get; set; }
    }

}

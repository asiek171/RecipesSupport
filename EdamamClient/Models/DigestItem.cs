using System.Text.Json.Serialization;

namespace EdamamClient.Models
{
    public class DigestItem
    {
        [JsonPropertyName("label")]
        public string Label { get; set; } = default!;

        [JsonPropertyName("tag")]
        public string Tag { get; set; } = default!;

        [JsonPropertyName("schemaOrgTag")]
        public string? SchemaOrgTag { get; set; }

        [JsonPropertyName("total")]
        public double Total { get; set; }

        [JsonPropertyName("hasRDI")]
        public bool HasRdi { get; set; }

        [JsonPropertyName("daily")]
        public double Daily { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; } = default!;

        [JsonPropertyName("sub")]
        public List<DigestSubItem>? Sub { get; set; }
    }
}

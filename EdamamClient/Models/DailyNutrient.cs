using System.Text.Json.Serialization;

namespace EdamamClient.Models
{
    public class DailyNutrient
    {
        [JsonPropertyName("label")]
        public string Label { get; set; } = default!;

        [JsonPropertyName("quantity")]
        public double Quantity { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; } = default!;
    }
}

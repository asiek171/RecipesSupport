using System.Text.Json.Serialization;

namespace EdamamClient.Models
{
    public class Ingredient
    {
        [JsonPropertyName("text")]
        public string Text { get; set; } = default!;
        [JsonPropertyName("quantity")]
        public double Quantity { get; set; }
        [JsonPropertyName("measure")]
        public string? Measure { get; set; }
        [JsonPropertyName("food")]
        public string Food { get; set; } = default!;
        [JsonPropertyName("weight")]
        public double Weight { get; set; }
        [JsonPropertyName("foodCategory")]
        public string FoodCategory { get; set; } = default!;
        [JsonPropertyName("image")]
        public string? Image { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace EdamamClient.Models
{
    public class EdamamNutritionDataResponse
    {
        [JsonPropertyName("uri")]
        public string Uri { get; set; } = default!;

        [JsonPropertyName("calories")]
        public double Calories { get; set; }

        [JsonPropertyName("totalCO2Emissions")]
        public double TotalCO2Emissions { get; set; }

        [JsonPropertyName("totalWeight")]
        public double TotalWeight { get; set; }

        [JsonPropertyName("dietLabels")]
        public List<string> DietLabels { get; set; } = [];

        [JsonPropertyName("healthLabels")]
        public List<string> HealthLabels { get; set; } = [];

        [JsonPropertyName("cautions")]
        public List<string> Cautions { get; set; } = [];

        [JsonPropertyName("totalNutrients")]
        public Dictionary<string, Nutrient> TotalNutrients { get; set; } = [];

        [JsonPropertyName("totalDaily")]
        public Dictionary<string, DailyValue> TotalDaily { get; set; } = [];

        [JsonPropertyName("ingredients")]
        public List<Ingredient> Ingredients { get; set; } = [];

        [JsonPropertyName("totalNutrientsKCal")]
        public Dictionary<string, NutrientKCal> TotalNutrientsKCal { get; set; } = [];
    }
}

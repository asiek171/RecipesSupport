using System.Text.Json.Serialization;

namespace EdamamClient.Models
{
    public class Recipe
    {
        [JsonPropertyName("uri")]
        public string Uri { get; set; } = default!;
        [JsonPropertyName("label")]
        public string Label { get; set; } = default!;
        [JsonPropertyName("image")]
        public string Image { get; set; } = default!;
        [JsonPropertyName("source")]
        public string Source { get; set; } = default!;
        [JsonPropertyName("url")]
        public string Url { get; set; } = default!;
        [JsonPropertyName("shareAs")]
        public string ShareAs { get; set; } = default!;

        [JsonPropertyName("yield")]
        public double Yield { get; set; }

        [JsonPropertyName("dietLabels")]
        public List<string> DietLabels { get; set; } = [];
        [JsonPropertyName("healthLabels")]
        public List<string> HealthLabels { get; set; } = [];
        [JsonPropertyName("cautions")]
        public List<string> Cautions { get; set; } = [];

        [JsonPropertyName("ingredientLines")]
        public List<string> IngredientLines { get; set; } = [];
        [JsonPropertyName("ingredients")]
        public List<Ingredient> Ingredients { get; set; } = [];
        [JsonPropertyName("calories")]
        public double Calories { get; set; }
        [JsonPropertyName("totalWeight")]
        public double TotalWeight { get; set; }
        [JsonPropertyName("totalTime")]
        public double TotalTime { get; set; }
        [JsonPropertyName("cuisineType")]
        public List<string> CuisineType { get; set; } = [];
        [JsonPropertyName("mealType")]
        public List<string> MealType { get; set; } = [];
        [JsonPropertyName("dishType")]
        public List<string> DishType { get; set; } = [];
        [JsonPropertyName("totalNutrients")]
        public Dictionary<string, Nutrient> TotalNutrients { get; set; } = [];

        [JsonPropertyName("images")]
        public Dictionary<string, ImageInfo> Images { get; set; } = [];

        [JsonPropertyName("digest")]
        public List<DigestItem> Digest { get; set; } = [];

        [JsonPropertyName("totalDaily")]
        public Dictionary<string, DailyNutrient> TotalDaily { get; set; } = [];
    }

}

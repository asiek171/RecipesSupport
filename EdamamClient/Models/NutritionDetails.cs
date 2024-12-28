namespace EdamamClient.Models
{
    public class NutritionDetails
    {
        public string? Title { get; set; }
        public string[]? Ingredients { get; set; }
        public string? Url { get; set; }
        public string? Summary { get; set; }
        public int Yield { get; set; }
        public string? Time { get; set; }
        public string? Img { get; set; }
        public List<string>? Prep { get; set; }
    }
}

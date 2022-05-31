using System.Text.Json.Serialization;

namespace SEP6_Blazor.Models
{
    public class MovieRole
    {
        [JsonPropertyName("original_title")] public string OriginalTitle { get; set; }
        [JsonPropertyName("original_language")] public string OriginalLanguage { get; set; } = "";
        [JsonPropertyName("title")] public string EnglishTitle { get; set; } = "";
        [JsonPropertyName("original_name")] public string OriginalName { get; set; }
        [JsonPropertyName("name")] public string EnglishName { get; set; } = "";
        [JsonPropertyName("character")] public string Character { get; set; }
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("vote_average")] public double VoteAverage { get; set; }
    }
}
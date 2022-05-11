using System.Text.Json.Serialization;

namespace SEP6_Blazor.Models
{
    public class Movie
    {
        [JsonPropertyName("id")] 
        public int Id { get; set; }

        [JsonPropertyName("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonPropertyName("original_title")]
        public string OriginalTitle { get; set; }

        [JsonPropertyName("overview")]
        public string Overview { get; set; }

        [JsonPropertyName("poster_path")]
        public string poster_path { get; set; }
    }
}

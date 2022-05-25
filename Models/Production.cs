using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SEP6_Blazor.Models
{
    public class Production
    {
        [JsonPropertyName("id")] public int Id { get; set; }

        [JsonPropertyName("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonPropertyName("original_title")] public string MovieName { get; set; }

        [JsonPropertyName("overview")] public string Overview { get; set; }

        [JsonPropertyName("poster_path")] public string Poster_path { get; set; }

        [JsonPropertyName("vote_average")] public double VoteAverage { get; set; }
        
        [JsonPropertyName("vote_count")] public int VoteCount { get; set; }

        [JsonPropertyName("genres")]
        public List<Genre> MovieGenres { get; set; } //only for movies! - don't use for tvshow

        [JsonPropertyName("original_name")] public string TVShowName { get; set; }
    }
}
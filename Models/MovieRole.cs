using System.Text.Json.Serialization;

namespace SEP6_Blazor.Models
{
    public class MovieRole
    {
        [JsonPropertyName("original_title")]
        public string OriginalTitle { get; set; }

        [JsonPropertyName("character")]
        public string Character { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}

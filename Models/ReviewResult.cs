using System.Text.Json.Serialization;

namespace SEP6_Blazor.Models
{
    public class ReviewResult
    {
        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }
    }
}

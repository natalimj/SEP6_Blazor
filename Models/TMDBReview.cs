using System.Text.Json.Serialization;

namespace SEP6_Blazor.Models
{
    public class TMDBReview
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("results")]
        public List<ReviewResult> Reviews { get; set; }
     
    }
}

using System.Text.Json.Serialization;

namespace SEP6_Blazor.Models

{
    public class Results
    {
        [JsonPropertyName("results")]
        public List<Movie> MovieResults { get; set; }
    }
}

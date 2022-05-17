using System.Text.Json.Serialization;

namespace SEP6_Blazor.Models
{
    //for company and people
    public class SearchResults
    {
        [JsonPropertyName("results")]
        public List<SearchResult> Results { get; set; } = new List<SearchResult>();
    }
}

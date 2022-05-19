using System.Text.Json.Serialization;

namespace SEP6_Blazor.Models
{
    public class PersonResults
    {
        [JsonPropertyName("results")]
        public List<PersonResult> Results { get; set; } = new List<PersonResult>();
    }
}

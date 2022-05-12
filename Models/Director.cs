using System.Text.Json.Serialization;

namespace SEP6_Blazor.Models
{
    public class Director
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("job")]
        public string Job { get; set; }
    }
}

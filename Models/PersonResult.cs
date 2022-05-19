using System.Text.Json.Serialization;

namespace SEP6_Blazor.Models
{
    public class PersonResult
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace SEP6_Blazor.Models
{
    public class Genre
    {
        [JsonPropertyName("id")] public int Id { get; set; }

        [JsonPropertyName("name")] public string Name { get; set; }
    }
}
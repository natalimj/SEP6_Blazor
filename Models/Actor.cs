using System.Text.Json.Serialization;

namespace SEP6_Blazor.Models
{
    public class Actor
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("character")]
        public string Character { get; set; }

        [JsonPropertyName("cast_id")]
        public int CastId { get; set; }

        [JsonPropertyName("profile_path")]
        public string ProfilePath { get; set; }

    }
}

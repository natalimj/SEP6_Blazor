using System.Text.Json.Serialization;

namespace SEP6_Blazor.Models
{
    public class Language
    {
        [JsonPropertyName("iso_639_1")]
        public string Iso_639_1 { get; set; }

        [JsonPropertyName("english_name")]
        public string EnglishName { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace SEP6_Blazor.Models
{
    public class Genres
    {
        [JsonPropertyName("genres")]

        public List<Genre> GenreList { get; set; } = new List<Genre>();
    }
}

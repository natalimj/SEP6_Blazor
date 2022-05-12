using System.Text.Json.Serialization;

namespace SEP6_Blazor.Models
{
    public class MovieCredits
    {

        [JsonPropertyName("cast")]
        public List<MovieRole> Roles { get; set; }

        public MovieCredits()
        {
            Roles = new List<MovieRole>();
        }
    }
}

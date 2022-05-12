using System.Text.Json.Serialization;

namespace SEP6_Blazor.Models
{
    public class Person
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("place_of_birth")]
        public string PlaceOfBirth { get; set; }

        [JsonPropertyName("biography")]
        public string Biography { get; set; }

        [JsonPropertyName("gender")]
        public bool gender;

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("movie_credits")]
        public MovieCredits MovieCredits { get; set; }

        [JsonPropertyName("profile_path")]
        public string ProfilePath { get; set; }


        // in blazor : src='@("https://image.tmdb.org/t/p/w500" + person.ProfilePath)'
    }
}

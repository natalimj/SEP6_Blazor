using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SEP6_Blazor.Models
{
    public class Crew
    {
        [JsonPropertyName("crew")] public List<Director> Directors { get; set; }

        public Crew()
        {
            Directors = new List<Director>();
        }
    }
}
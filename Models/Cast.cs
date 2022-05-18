using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SEP6_Blazor.Models
{
    public class Cast
    {
        [JsonPropertyName("cast")]
        public List<Actor> Actors { get; set; }
        public Cast()
        {
            Actors = new List<Actor>();
        }
    }
}

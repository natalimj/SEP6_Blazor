using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SEP6_Blazor.Models
{
    public class Images
    {
        [JsonPropertyName("backdrops")] public List<Image> Backdrops { get; set; }
    }
}
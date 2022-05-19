using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SEP6_Blazor.Models

{
    public class Results
    {
        [JsonPropertyName("results")] public List<Production> ProductionResults { get; set; } = new List<Production>();
    }
}
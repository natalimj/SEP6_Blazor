using System.Text.Json.Serialization;

namespace SEP6_Blazor.Models
{
    public class ListItem
    {
        [JsonPropertyName("productionid")] public string ProductionId { get; set; }

        [JsonPropertyName("type")] public string Type { get; set; }

        public ListItem()
        {
        }

        public ListItem(string productionId, string type)
        {
            ProductionId = productionId;
            Type = type;
        }
    }
}
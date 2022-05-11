using System.Text.Json.Serialization;

namespace SEP6_Blazor.Models
{
    public class Image
    {
        [JsonPropertyName("file_path")]
        public string FilePath { get; set; }
    }
}

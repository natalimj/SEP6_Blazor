using System.Text.Json.Serialization;

namespace SEP6_Blazor.Models
{
    public class Review
    {
        [JsonPropertyName("id")] public string Id { get; set; }

        [JsonPropertyName("userid")] public string UserId { get; set; }

        [JsonPropertyName("productionid")] public string ProductionId { get; set; }

        [JsonPropertyName("type")] public string Type { get; set; }

        [JsonPropertyName("review")] public string UserReview { get; set; }
        
        public Review(){}

        public Review(string userId, string productionId, string type, string userReview)
        {
            UserId = userId;
            ProductionId = productionId;
            Type = type;
            UserReview = userReview;
        }
    }
}
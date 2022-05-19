﻿using System.Text.Json.Serialization;

namespace SEP6_Blazor.Models
{
    public class Rating
    {
        [JsonPropertyName("id")] public string Id { get; set; }

        [JsonPropertyName("userid")] public string UserId { get; set; }

        [JsonPropertyName("productionid")] public string ProductionId { get; set; }

        [JsonPropertyName("type")] public string Type { get; set; }

        [JsonPropertyName("rating")] public int UserRating { get; set; }

        public Rating(string userId, string productionId, string type, int userRating)
        {
            UserId = userId;
            ProductionId = productionId;
            Type = type;
            UserRating = userRating;
        }
    }
}
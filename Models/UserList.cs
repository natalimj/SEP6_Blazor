﻿using System.Text.Json.Serialization;

namespace SEP6_Blazor.Models
{
    public class UserList
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("userid")]
        public string UserId { get; set; }

        [JsonPropertyName("listname")]
        public string ListName { get; set; }

        [JsonPropertyName("listItems")]
        public List<ListItem> ListItems { get; set; }
    }
}

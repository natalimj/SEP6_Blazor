using System.Collections.Generic;
using System.Text.Json.Serialization;

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
        public List<ListItem> ListItems { get; set; } = new List<ListItem>();
        
        public UserList()
        {}
        public UserList(string userId, string listName, List<ListItem> listItems)
        {
            UserId = userId;
            ListName = listName;
            ListItems = listItems;
        }
    }
}

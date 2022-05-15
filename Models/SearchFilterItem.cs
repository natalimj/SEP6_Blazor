namespace SEP6_Blazor.Models
{
    public class SearchFilterItem
    {
        public SearchFilterItem(string displayName, string url, string? type,int id)
        {
            DisplayName = displayName;
            URL = url;
            Type = type;
            Id = id;
        }
        
        public SearchFilterItem(string displayName, string url, int id)
        {
            DisplayName = displayName;
            URL = url;
            Type = "text";
            Id = id;
        }

        public string DisplayName { get; set; }
        public string URL { get; set; }
        public string? Type { get; set; }
        public int Id { get; set; }
        public string? Value { get; set; }
    }
}
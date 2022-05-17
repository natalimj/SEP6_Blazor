using SEP6_Blazor.Models;
using System.Text.Json;

namespace SEP6_Blazor.Data
{
    public class SearchService
    {
        private string uri = "https://api.themoviedb.org/3/";
        private string apiKey = "?api_key=63335424114024b0bdbf981fe8c972e0";
        private readonly HttpClient client = new();


        public async Task<Results> SearchProduction(string query, string productionType)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "search/" + productionType + apiKey + "&query=" + query);
            string message = await stringAsync;
            Results result = JsonSerializer.Deserialize<Results>(message);
            return result;
        }


        //searchType "person" or "company"
        public async Task<SearchResults> SearchPersonOrCompany(string query,string searchType)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "search/" + searchType+ apiKey + "&query=" + query);
            string message = await stringAsync;
            SearchResults result = JsonSerializer.Deserialize<SearchResults>(message);
            return result;

        }

    }
}

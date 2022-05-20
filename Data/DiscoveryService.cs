using SEP6_Blazor.Models;
using System.Text.Json;

namespace SEP6_Blazor.Data
{
    public class DiscoveryService : IDiscoveryService
    {

        private string uri = "https://api.themoviedb.org/3/";
        private string apiKey = "?api_key=63335424114024b0bdbf981fe8c972e0";
        private readonly HttpClient client = new();

        public async Task<List<Language>> GetLanguages()
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "configuration/languages" + apiKey);
            string message = await stringAsync;
            List<Language> result = JsonSerializer.Deserialize<List<Language>>(message);
            return result;
        }


        public async Task<List<Genre>> GetGenres(string productionType)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "genre/"+productionType+"/list"+ apiKey);
            string message = await stringAsync;
            Genres result = JsonSerializer.Deserialize<Genres>(message);
            return result.GenreList;
        }
    }
}

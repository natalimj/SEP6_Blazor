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

        public async Task<Results> DiscoveryProduction(string productionType, string language, string year, 
            string minRating, string maxRating, string minRuntime, string maxRuntime, string personId, string genre)
        {
            string baseUrl = uri + "discover/" + productionType + apiKey 
                + "&sort_by=popularity.desc&include_adult=false&include_video=false";

            if (!year.Equals(""))
            {
                baseUrl += "&primary_release_year=" + year;
            }
            if (!minRating.Equals(""))
            {
                baseUrl += "&vote_average.gte=" + minRating;
            }
            if (!maxRating.Equals(""))
            {
                baseUrl += "&vote_average.lte=" + maxRating;
            }
            if (!personId.Equals(""))
            {
                baseUrl += "&with_people=" + personId;
            }
            if (!genre.Equals(""))
            {
                genre = genre.Replace(",", "%2C");
                baseUrl += "&with_genres=" + genre;
            }
            if (!minRuntime.Equals(""))
            {
                baseUrl += "with_runtime.gte" + minRuntime;
            }
            if (!maxRuntime.Equals(""))
            {
                baseUrl += "&with_runtime.lte=" + maxRuntime;
            }
            if (!language.Equals(""))
            {
                baseUrl += "&with_original_language=" + language;
            }

            Task<string> stringAsync = client.GetStringAsync(baseUrl);
            string message = await stringAsync;
            Results result = JsonSerializer.Deserialize<Results>(message);
            return result;
        }
    }
}

using SEP6_Blazor.Models;
using System.Text.Json;

namespace SEP6_Blazor.Data
{
    public class TVService : ITVService
    {

        private string uri = "https://api.themoviedb.org/3/";
        private string apiKey = "?api_key=63335424114024b0bdbf981fe8c972e0";
        private readonly HttpClient _client = new();

        //https://api.themoviedb.org/3/search/tv?api_key=63335424114024b0bdbf981fe8c972e0&query=hello

        public async Task<Results> SearchTVShow(string query)
        {
            string message = await _client.GetStringAsync(uri + "search/tv" + apiKey + "&query=" + query);
            Results result = JsonSerializer.Deserialize<Results>(message);
            return result;
        }

        //https://api.themoviedb.org/3/tv/69740?api_key=63335424114024b0bdbf981fe8c972e0
        //
        public async Task<TVShow> GetTVShow(string id)
        {
            string message = await _client.GetStringAsync(uri + "tv/" + id + apiKey);
            TVShow result = JsonSerializer.Deserialize<TVShow>(message);
            return result;
        }


        //https://api.themoviedb.org/3/tv/69740/images?api_key=63335424114024b0bdbf981fe8c972e0
        //https://api.themoviedb.org/3/tv/69740/images?api_key=63335424114024b0bdbf981fe8c972e0
        public async Task<Images> GetTVShowImagesUrl(string id)
        {
            string message = await _client.GetStringAsync(uri + "tv/" + id + "/images" + apiKey);
            Images result = JsonSerializer.Deserialize<Images>(message);

            return result;
        }


        //https://api.themoviedb.org/3/movie/69740/credits?api_key=63335424114024b0bdbf981fe8c972e0
        public async Task<Cast> GetTVShowCast(string id)
        {
            string message = await _client.GetStringAsync(uri + "tv/" + id + "/credits" + apiKey);
            Cast result = JsonSerializer.Deserialize<Cast>(message);

            return result;
        }
    }
}

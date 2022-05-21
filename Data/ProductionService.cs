using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using SEP6_Blazor.Models;
using System.Text.Json;
using System.Threading.Tasks;

namespace SEP6_Blazor.Data
{
    public class ProductionService : IProductionService
    {
        private string uri = "https://api.themoviedb.org/3/";
        private string apiKey = "?api_key=63335424114024b0bdbf981fe8c972e0";
        private readonly HttpClient client = new();

        // production type : "movie" or "tv"
        // id : productionid (movieId or TVId)

        public async Task<Results> SearchProduction(string query, string productionType)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "search/" + productionType + apiKey + "&query=" + query);
            string message = await stringAsync;
            Results result = JsonSerializer.Deserialize<Results>(message);
            return result;
        }

        public async Task<Production> GetProduction(string id, string productionType)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + productionType + "/" + id + apiKey);
            string message = await stringAsync;
            Production result = JsonSerializer.Deserialize<Production>(message);
            return result;
        }

        public async Task<Images> GetProductionImagesUrl(string id, string productionType)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + productionType + "/" + id + "/images" + apiKey);
            string message = await stringAsync;
            Images result = JsonSerializer.Deserialize<Images>(message);

            return result;
        }

        public async Task<Cast> GetCast(string id, string productionType)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + productionType + "/" + id + "/credits" + apiKey);
            string message = await stringAsync;
            Cast result = JsonSerializer.Deserialize<Cast>(message);
            return result;
        }

        public async Task<List<Director>> GetDirector(string id, string productionType)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + productionType + "/" + id + "/credits" + apiKey);
            string message = await stringAsync;
            Crew result = JsonSerializer.Deserialize<Crew>(message);

            List<Director> directors = result.Directors.Where(x => x.Job.Equals("Director")).ToList();

            return directors;
        }

        public async Task<Results> GetRecommendedProductions(string id, string productionType)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + productionType + "/" + id + "/recommendations" + apiKey);
            string message = await stringAsync;
            Results result = JsonSerializer.Deserialize<Results>(message);
            return result;
        }

        public async Task<Results> GetSimilarProductions(string id, string productionType)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + productionType + "/" + id + "/similar" + apiKey);
            string message = await stringAsync;
            Results result = JsonSerializer.Deserialize<Results>(message);
            return result;
        }

        public async Task<Results> GetPopularProductions(string productionType)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + productionType + "/popular" + apiKey);
            string message = await stringAsync;
            Results result = JsonSerializer.Deserialize<Results>(message);
            return result;
        }

        public async Task<Production> GetLatestProduction(string productionType)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + productionType + "/latest" + apiKey);
            string message = await stringAsync;
            Production result = JsonSerializer.Deserialize<Production>(message);
            return result;
        }

        public async Task<Results> GetTopRatedProduction(string productionType)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + productionType + "/top_rated" + apiKey);
            string message = await stringAsync;
            Results result = JsonSerializer.Deserialize<Results>(message);
            return result;
        }

        public async Task<Results> GetUpcomingMovies()
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "movie/upcoming" + apiKey);
            string message = await stringAsync;
            Results result = JsonSerializer.Deserialize<Results>(message);
            return result;
        }


        public async Task<TMDBReview> GetProductionReviews(string id, string productionType)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + productionType + "/" + id + "/reviews" + apiKey);
            string message = await stringAsync;
            TMDBReview result = JsonSerializer.Deserialize<TMDBReview>(message);
            return result;

        }
    }
}

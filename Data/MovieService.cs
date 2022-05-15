using SEP6_Blazor.Models;
using System.Text.Json;

namespace SEP6_Blazor.Data
{
    public class MovieService :IMovieService
    {
        private string uri = "https://api.themoviedb.org/3/";
        private string apiKey = "?api_key=63335424114024b0bdbf981fe8c972e0";
        private readonly HttpClient client = new ();


        // https://api.themoviedb.org/3/search/movie?api_key=63335424114024b0bdbf981fe8c972e0&query=Jack+Reacher

        public async Task<Results> SearchMovie(string query)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "search/movie" + apiKey + "&query=" + query);
            string message = await stringAsync;
            Results result = JsonSerializer.Deserialize<Results>(message);
            return result;
        }

        //https://api.themoviedb.org/3/movie/752623?api_key=63335424114024b0bdbf981fe8c972e0
        public async Task<Movie> GetMovie(string id)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "movie/" + id + apiKey);
            string message = await stringAsync;
            Movie result = JsonSerializer.Deserialize<Movie>(message);
            return result;
        }

        //https://api.themoviedb.org/3/movie/752623/images?api_key=63335424114024b0bdbf981fe8c972e0
        public async Task<Images> GetMovieImagesUrl(string id)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "movie/" + id + "/images" + apiKey);
            string message = await stringAsync;
            Images result = JsonSerializer.Deserialize<Images>(message);

            return result;
        }

        //https://api.themoviedb.org/3/movie/752623/credits?api_key=63335424114024b0bdbf981fe8c972e0
        public async Task<Cast> GetCast(string id)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "movie/" + id + "/credits" + apiKey);
            string message = await stringAsync;
            Cast result = JsonSerializer.Deserialize<Cast>(message);
            return result;
        }

        public async Task<List<Director>> GetDirector(string id)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "movie/" + id + "/credits" + apiKey);
            string message = await stringAsync;
            Crew result = JsonSerializer.Deserialize<Crew>(message);

            List<Director> directors = result.Directors.Where(x => x.Job.Equals("Director")).ToList();

            return directors;
        }

        //https://api.themoviedb.org/3/movie/752623/recommendations?api_key=63335424114024b0bdbf981fe8c972e0&page=1
        public async Task<Results> GetRecommendedMovies(string id)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "movie/" + id + "/recommendations" + apiKey);
            string message = await stringAsync;
            Results result = JsonSerializer.Deserialize<Results>(message);
            return result;
        }

        //https://api.themoviedb.org/3/movie/752623/similar?api_key=63335424114024b0bdbf981fe8c972e0&page=1
        public async Task<Results> GetSimilarMovies(string id)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "movie/" + id + "/similar" + apiKey);
            string message = await stringAsync;
            Results result = JsonSerializer.Deserialize<Results>(message);
            return result;
        }

        //https://api.themoviedb.org/3/movie/popular?api_key=63335424114024b0bdbf981fe8c972e0&page=1
        public async Task<Results> GetPopularMovies()
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "movie/popular" + apiKey);
            string message = await stringAsync;
            Results result = JsonSerializer.Deserialize<Results>(message);
            return result;
        }

        //https://api.themoviedb.org/3/movie/upcoming?api_key=63335424114024b0bdbf981fe8c972e0&page=1
        public async Task<Results> GetUpcomingMovies()
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "movie/upcoming" + apiKey);
            string message = await stringAsync;
            Results result = JsonSerializer.Deserialize<Results>(message);
            return result;
        }

        //https://api.themoviedb.org/3/movie/top_rated?api_key=63335424114024b0bdbf981fe8c972e0&page=1
        public async Task<Results> GetTopRatedMovies()
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "movie/top_rated" + apiKey);
            string message = await stringAsync;
            Results result = JsonSerializer.Deserialize<Results>(message);
            return result;
        }

    }
}

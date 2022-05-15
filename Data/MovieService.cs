using SEP6_Blazor.Models;
using System.Text.Json;

namespace SEP6_Blazor.Data
{
    public class MovieService :IMovieService
    {
        private string uri = "https://api.themoviedb.org/3/";
        private string apiKey = "?api_key=63335424114024b0bdbf981fe8c972e0";
        private readonly HttpClient _client = new ();


        // https://api.themoviedb.org/3/search/movie?api_key=63335424114024b0bdbf981fe8c972e0&query=Jack+Reacher

        public async Task<Results> SearchMovie(string query)
        {
            string message = await _client.GetStringAsync(uri + "search/movie" + apiKey + "&query=" + query);
            Results result = JsonSerializer.Deserialize<Results>(message);
            return result;
        }

        //https://api.themoviedb.org/3/movie/752623?api_key=63335424114024b0bdbf981fe8c972e0
        public async Task<Movie> GetMovie(string id)
        {
            string message = await _client.GetStringAsync(uri + "movie/" + id + apiKey);
            Movie result = JsonSerializer.Deserialize<Movie>(message);
            return result;
        }

        //https://api.themoviedb.org/3/movie/752623/images?api_key=63335424114024b0bdbf981fe8c972e0
        public async Task<Images> GetMovieImagesUrl(string id)
        {
            string message = await _client.GetStringAsync(uri + "movie/" + id + "/images" + apiKey);
            Images result = JsonSerializer.Deserialize<Images>(message);

            return result;
        }

        //https://api.themoviedb.org/3/movie/752623/credits?api_key=63335424114024b0bdbf981fe8c972e0
        public async Task<Cast> GetCast(string id)
        {
            string message = await _client.GetStringAsync(uri + "movie/" + id + "/credits" + apiKey);
            Cast result = JsonSerializer.Deserialize<Cast>(message);

            return result;
        }

        public async Task<List<Director>> GetDirector(string id)
        {
            string message = await _client.GetStringAsync(uri + "movie/" + id + "/credits" + apiKey);
            Crew result = JsonSerializer.Deserialize<Crew>(message);

            List<Director> directors = result.Directors.Where(x => x.Job.Equals("Director")).ToList();

            return directors;
        }

        //https://api.themoviedb.org/3/movie/752623/recommendations?api_key=63335424114024b0bdbf981fe8c972e0&page=1
        public async Task<List<Movie>> GetRecommendedMovies(string id)
        {
            string message = await _client.GetStringAsync(uri + "movie/" + id + "/recommendations" + apiKey);
            List<Movie> result = JsonSerializer.Deserialize<List<Movie>>(message);
            return result;
        }

        //https://api.themoviedb.org/3/movie/752623/similar?api_key=63335424114024b0bdbf981fe8c972e0&page=1
        public async Task<List<Movie>> GetSimilarMovies(string id)
        {
            string message = await _client.GetStringAsync(uri + "movie/" + id + "/similar" + apiKey);
            List<Movie> result = JsonSerializer.Deserialize<List<Movie>>(message);
            return result;
        }

        //https://api.themoviedb.org/3/movie/popular?api_key=63335424114024b0bdbf981fe8c972e0&page=1
        public async Task<List<Movie>> GetPopularMovies()
        {
            string message = await _client.GetStringAsync(uri + "movie/popular" + apiKey);
            List<Movie> result = JsonSerializer.Deserialize<List<Movie>>(message);
            return result;
        }

        //https://api.themoviedb.org/3/movie/upcoming?api_key=63335424114024b0bdbf981fe8c972e0&page=1
        public async Task<List<Movie>> GetUpcomingMovies()
        {
            string message = await _client.GetStringAsync(uri + "movie/upcoming" + apiKey);
            List<Movie> result = JsonSerializer.Deserialize<List<Movie>>(message);
            return result;
        }

        //https://api.themoviedb.org/3/movie/top_rated?api_key=63335424114024b0bdbf981fe8c972e0&page=1
        public async Task<List<Movie>> GetTopRatedMovies()
        {
            string message = await _client.GetStringAsync(uri + "movie/top_rated" + apiKey);
            List<Movie> result = JsonSerializer.Deserialize<List<Movie>>(message);
            return result;
        }

    }
}
